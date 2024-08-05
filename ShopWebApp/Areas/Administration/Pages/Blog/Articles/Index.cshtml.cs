using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel;
        public List<ArticleViewModel> Articles { get; set; }

        private readonly IArticleApplication _articleApplication;
        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = _articleApplication.Search(searchModel);
        }

    }
}
