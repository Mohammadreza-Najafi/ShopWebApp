﻿using _0_Framwork.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long,ArticleCategory>
    {
        string GetSlugBy(long id);
        List<ArticleCategoryViewModel> GetArticleCategories();
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

    }
}
