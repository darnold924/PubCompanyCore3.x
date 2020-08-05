using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor3.x.Models;

namespace WebRazor3.x.Pages.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleDM _articleDm;
        public CreateModel(IArticleDM articleDm)
        {
            _articleDm = articleDm;
        }

        [BindProperty]
        public ArticleVM.Article Article { get; set; }
        public IActionResult OnGet(int id)
        {
            Article = _articleDm.Add(id);
            return Page();
        }

        public IActionResult OnPost(string submit)
        {
            if (submit == "Cancel")
                return RedirectToPage("ArticleIndex", new {id = Article.AuthorId});

            if (!ModelState.IsValid)
                return Page();
            
            _articleDm.Add(Article);
            return RedirectToPage("ArticleIndex", new {id = Article.AuthorId});
        }
    }
}