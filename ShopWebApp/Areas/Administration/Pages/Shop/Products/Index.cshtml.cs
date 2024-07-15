using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopWebApp.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {

        public List<ProductViewModel> Products { get; set; }
        //[TempData]
        //public string Message { get; set; }
        //public ProductSearchModel SearchModel { get; set; }

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
        }

    }
}
