using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;


namespace ShopWebApp.Areas.Administration.Pages.Shop.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProduct Product { get; set; }

        public List<ProductCategoryViewModel> Categories;

        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(long id)
        {
            Categories = _productCategoryApplication.GetProductCategories();
            Product = _productApplication.GetDetails(id);
        }

            
        public IActionResult OnPost()
        {
            _productApplication.Edit(Product);

            return RedirectToPage("./Index");
        }
    }
}
