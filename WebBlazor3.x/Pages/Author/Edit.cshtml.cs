using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Author
{
    public class EditModel : PageModel
    {
        private readonly IAuthorDM _authorDm;
        public EditModel(IAuthorDM authorDm)
        {
            _authorDm = authorDm;
        }

        [BindProperty]
        public AuthorVM.Author Author { get; set; } 
        public IActionResult OnGet(int id)
        {
            Author = _authorDm.Find(id);
            return Page();
        }

        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel")
                return RedirectToPage("Index");

            if (!ModelState.IsValid)
                return Page();

            _authorDm.Update(Author);

            return RedirectToPage("Index");
        }
    }
}