using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.PayRoll
{
    public class IndexModel : PageModel
    {
        private readonly IPayRollDM _payrollDm;
        public IndexModel(IPayRollDM payrollDm)
        {
            _payrollDm = payrollDm;
        }

        [BindProperty]
        public PayRollVM PayRollVM { get; set; }
        public IActionResult OnGet()
        {
            PayRollVM = _payrollDm.GetAll();
            return Page();
        }
        
        public IActionResult OnGetDelete(int id)
        {
            _payrollDm.Delete(id);
            return RedirectToPage("Index");
        }
    }
}