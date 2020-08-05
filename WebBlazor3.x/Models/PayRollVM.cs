using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebRazor3.x.Models
{
    public class PayRollVM
    {
        public class Payroll
        {
            public int PayRollId { get; set; }
            public int AuthorId { get; set; }
            public string AuthorFirstName { get; set; }
            public string AuthorLastName { get; set; }

            [Required(ErrorMessage = "Author is required")]
            public string AuthorTypeId { get; set; }

            [Required(ErrorMessage = "Salary is required")]
            public int? Salary { get; set; }

            public List<SelectListItem> AuthorTypes { get; set; } = new List<SelectListItem>();

        }
        public List<Payroll> Payrolls { get; set; } = new List<Payroll>();
    }
}
