using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Author
{
    public class IndexModel : PageModel
    {
        private readonly IAuthorDM _authorDm;
        public IndexModel(IAuthorDM authorDm)
        {
            _authorDm = authorDm;
        }

        [BindProperty]
        public AuthorVM AuthorVM { get; set; } 
        public IActionResult OnGet()
        {
            AuthorVM = _authorDm.GetAll();
            return Page();
        }

        public IActionResult OnGetDelete(int id)
        {
            _authorDm.Delete(id);
            return RedirectToPage("Index");
        }
    }
}