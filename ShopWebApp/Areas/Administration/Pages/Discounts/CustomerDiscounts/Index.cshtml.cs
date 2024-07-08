using DiscountManagement.Application.Contract;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class IndexModel : PageModel
    {

        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }
        //[TempData]
        //public string Message { get; set; }
        //public ProductSearchModel SearchModel { get; set; }
        //public SelectList ProductCategories;


        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
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
