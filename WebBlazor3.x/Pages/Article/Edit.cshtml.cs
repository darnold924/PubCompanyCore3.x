using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleDM _articleDm;
        public EditModel(IArticleDM articleDm)
        {
            _articleDm = articleDm;
        }

        [BindProperty]
        public ArticleVM.Article Article { get; set; }
        public IActionResult OnGet(int id)
        {
            Article = _articleDm.Update(id);
            return Page();
        }

        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel")
                return RedirectToPage("ArticleIndex", new { id = Article.AuthorId });

            if (!ModelState.IsValid)
                return Page();

            _articleDm.Update(Article);
            return RedirectToPage("ArticleIndex", new { id = Article.AuthorId });
        }
    }
}