using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel;
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }

    }
}
