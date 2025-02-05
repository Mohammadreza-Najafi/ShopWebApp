﻿using _0_Framwork.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Globalization;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleApplication(IFileUploader fileUploader, IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();

            if (_articleRepository.Exists(x => x.Title == command.Title))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";

            var pictureName = _fileUploader.Upload(command.Picture, path);

            DateTime publishDate;
            DateTime.TryParseExact(command.PublishDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishDate);

            var article = new Article(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords,
                command.MetaDescription, command.CanonicalAddress, command.CategoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();

            var article = _articleRepository.GetWithCategory(command.Id);

            if (article == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();

            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{article.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            DateTime publishDate;
            DateTime.TryParseExact(command.PublishDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishDate);

            article.Edit(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords,
                command.MetaDescription, command.CanonicalAddress, command.CategoryId);


            _articleRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
