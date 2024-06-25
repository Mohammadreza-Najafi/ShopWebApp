using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;


namespace ShopWebApp.Areas.Adminstration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {

        public ProductCategorySearchModel SearchModel { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductCategorySearchModel searchModel)
        {

            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnPostCreate(CreateProductCategory command) 
        {
             _productCategoryApplication.Create(command);

            return RedirectToPage("./Index");

        }
    }
}
