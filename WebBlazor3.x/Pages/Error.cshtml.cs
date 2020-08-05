using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public ErrorVM Error { get; set; }

        public IActionResult OnGet()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // Get which route the exception occurred at

            string routeWhereExceptionOccurred = exceptionFeature.Path;

            // Get the exception that occurred

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            Exception exceptionThatOccurred = exceptionFeature.Error;

            _logger.LogError("Request Id: " + RequestId + " " 
                             + routeWhereExceptionOccurred + " " + exceptionThatOccurred);
            return Page();

        }
    }
}
