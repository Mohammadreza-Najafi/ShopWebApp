using _0_Framwork.Domain;
using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetDetails(long id);
        Article GetWithCategory(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
