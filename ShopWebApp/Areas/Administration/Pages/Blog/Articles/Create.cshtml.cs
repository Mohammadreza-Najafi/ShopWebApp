using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateArticle Article { get; set; }
        public List<ArticleCategoryViewModel> ArticleCategories;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
           ArticleCategories = _articleCategoryApplication.GetArticleCategories();
        }

        public IActionResult OnPost()
        {
            _articleApplication.Create(Article);

            return RedirectToPage("Index");
        }
       
    }
}
