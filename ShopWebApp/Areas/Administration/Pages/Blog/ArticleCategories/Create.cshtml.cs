using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Create(ArticleCategory);
            return RedirectToPage("Index");
        }
       
    }
}
