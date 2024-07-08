using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopWebApp.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public DefineCustomerDiscount CustomerDiscount { get; set; }

        public List<ProductCategoryViewModel> Categories;

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
           
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            _customerDiscountApplication.Define(CustomerDiscount);

            return RedirectToPage("./Index");
        }

    }
}
