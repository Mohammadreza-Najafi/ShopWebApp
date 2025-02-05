using _01_ShopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(id);

        }
    }
}
