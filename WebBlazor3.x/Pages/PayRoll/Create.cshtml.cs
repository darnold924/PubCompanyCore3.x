using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.PayRoll
{
    public class CreateModel : PageModel
    {
        private readonly IPayRollDM _payrollDm;
        public CreateModel(IPayRollDM payrollDm)
        {
            _payrollDm = payrollDm;
        }

        [BindProperty]
        public PayRollVM.Payroll PayRoll { get; set; } 
        public IActionResult OnGet()
        {
            PayRoll = _payrollDm.Add();
            return Page();
        }

        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel") return RedirectToPage("Index");

            if (!ModelState.IsValid)
            {
                PayRoll = _payrollDm.PopulateSelectedList(PayRoll);
                return Page();
            }

            if (_payrollDm.BlnFindPayRollByAuthorId(int.Parse(PayRoll.AuthorTypeId)))
            {
                ModelState.AddModelError("AuthorTypeId", "Author has an existing PayRoll record.");
            }
            else
            {
                ModelState.Clear();
            }

            if (!ModelState.IsValid)
            {
                PayRoll = _payrollDm.PopulateSelectedList(PayRoll);
                return Page();
            }

            _payrollDm.Add(PayRoll);
            return RedirectToPage("Index");
            
        }
    }
}