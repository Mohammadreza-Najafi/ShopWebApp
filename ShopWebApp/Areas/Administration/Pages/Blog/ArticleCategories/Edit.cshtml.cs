using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.ArticleCategories
{ 
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.GetDetails(id);
        }

        public IActionResult OnPost()
        {

            _articleCategoryApplication.Edit(ArticleCategory);

            return RedirectToPage("./Index");
        }


    }
}
