using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.PayRoll
{
    public class EditModel : PageModel
    {
        private readonly IPayRollDM _payrollDm;
        public EditModel(IPayRollDM payrollDm)
        {
            _payrollDm = payrollDm;
        }

        [BindProperty]
        public PayRollVM.Payroll PayRoll { get; set; } 
        public IActionResult OnGet(int id)
        {
            
            PayRoll = _payrollDm.Update(id);
            return Page();
        }

        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel") return RedirectToPage("Index");
           
            if (!ModelState.IsValid)
                return Page();

            _payrollDm.Update(PayRoll);
            return RedirectToPage("Index");
        }
    }
}