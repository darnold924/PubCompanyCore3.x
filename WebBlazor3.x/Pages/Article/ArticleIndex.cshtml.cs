using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Article
{
    public class ArticleIndexModel : PageModel
    {
        private readonly IArticleDM _articleDm;
        public ArticleIndexModel(IArticleDM articleDm)
        {
            _articleDm = articleDm;
        }

        [BindProperty]
        public ArticleVM ArticleVM { get; set; } 

        [BindProperty]
        public int Authorid { get; set; }

        public IActionResult OnGet(int id)
        {
            TempData["AuthorId"] = id;
            Authorid = id;
            ArticleVM = _articleDm.GetArticlesByAuthorId(id);
            return Page();
        }

        public IActionResult OnGetDelete(int id)
        {
            _articleDm.Delete(id);
            return RedirectToPage("ArticleIndex?id=" + TempData["AuthorId"]);
        }
    }
}