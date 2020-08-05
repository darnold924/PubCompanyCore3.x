using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Author
{
    public class CreateModel : PageModel
    {
        private readonly IAuthorDM _authorDm;
        public CreateModel(IAuthorDM authorDm)
        {
            _authorDm = authorDm;
        }

        [BindProperty]
        public AuthorVM.Author Author { get; set; } 

        public IActionResult OnGet()
        {
            Author = _authorDm.Add();
            return Page();
        }
        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel")
                return RedirectToPage("Index");

            if (!ModelState.IsValid)
                return Page();

            _authorDm.Add(Author);

            return RedirectToPage("Index");
        }
    }
}