﻿
using _0_Framwork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryApplication
    {
        private readonly ShopContext _context;

    public ProductCategoryRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public EditProductCategory GetDetails(long id)
    {
        return _context.ProductCategories.Select(x => new EditProductCategory()
        {
            Id = x.Id,
            Description = x.Description,
            Name = x.Name,
            Keywords = x.Keywords,
            MetaDescription = x.MetaDescription,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Slug = x.Slug
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<ProductCategoryViewModel> GetProductCategories()
    {
        return _context.ProductCategories.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
    {
        var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Picture = x.Picture,
            Name = x.Name,
            CreationDate = x.CreationDate.ToString()
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));

        return query.OrderByDescending(x => x.Id).ToList();
    }


}
}
