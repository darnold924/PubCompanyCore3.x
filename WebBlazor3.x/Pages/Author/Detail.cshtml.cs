using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Author
{
    public class DetailModel : PageModel
    {
        private readonly IAuthorDM _authorDm;

        public DetailModel(IAuthorDM authorDm)
        {
            _authorDm = authorDm;
        }

        [BindProperty] public AuthorVM.Author Author { get; set; }

        public IActionResult OnGet(int id)
        {
            Author = _authorDm.Find(id);
            return Page();
        }
    }
}