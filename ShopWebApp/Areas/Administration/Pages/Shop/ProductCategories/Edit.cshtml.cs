using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopWebApp.Areas.Administration.Pages.Shop.ProductCategories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProductCategory ProductCategory { get; set; }

        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(long id)
        {
            ProductCategory = _productCategoryApplication.GetDetails(id);
        }

        public IActionResult OnPost()
        {            
            
            _productCategoryApplication.Edit(ProductCategory);

            return RedirectToPage("./Index");
        }


    }
}
