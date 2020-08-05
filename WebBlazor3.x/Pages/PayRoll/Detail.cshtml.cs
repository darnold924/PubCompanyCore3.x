using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.PayRoll
{
    public class DetailModel : PageModel
    {
        private readonly IPayRollDM _payrollDm;
        public DetailModel(IPayRollDM payrollDm)
        {
            _payrollDm = payrollDm;
        }

        [BindProperty]
        public PayRollVM.Payroll PayRoll { get; set; }
        public IActionResult OnGet(int id)
        {
            PayRoll = _payrollDm.Find(id);
            return Page();
        }
        
    }
}