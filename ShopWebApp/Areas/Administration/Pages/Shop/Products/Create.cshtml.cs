using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopWebApp.Areas.Administration.Pages.Shop.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateProduct CreateProduct { get; set; }

        public List<ProductCategoryViewModel> Categories;

        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet()
        {
            Categories = _productCategoryApplication.GetProductCategories();
        }

        public IActionResult OnPost()
        {
            _productApplication.Create(CreateProduct);

            return RedirectToPage("./Index");
        }

    }
}
