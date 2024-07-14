using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;


namespace ShopWebApp.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditCustomerDiscount CustomerDiscount { get; set; }

        public List<ProductViewModel> Products { get; set; }

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;

        }
        public void OnGet(long id)
        {
            CustomerDiscount = _customerDiscountApplication.GetDetails(id);
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost()
        {
            _customerDiscountApplication.Edit(CustomerDiscount);

            return RedirectToPage("./Index");
        }
    }
}
