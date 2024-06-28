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
        //public SelectList ProductCategories;

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

        public IActionResult OnGetNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);

            if (result.IsSuccedded)
            {               
                //Message = result.Message;
            }

            return RedirectToPage("./Index");

        }

        public IActionResult OnGetIsInStock(long id)
        {
            var result = _productApplication.IsStock(id);

            if (result.IsSuccedded)
            {
                //Message = result.Message;
            }

            return RedirectToPage("./Index");

        }
    }
}
