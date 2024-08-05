using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticle Article { get; set; }
        public List<ArticleCategoryViewModel> ArticleCategories;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleApplication.GetDetails(id);
            ArticleCategories = _articleCategoryApplication.GetArticleCategories();
        }

        public IActionResult OnPost()
        {
            _articleApplication.Edit(Article);

            return RedirectToPage("Index");
        }
    }


    
}
