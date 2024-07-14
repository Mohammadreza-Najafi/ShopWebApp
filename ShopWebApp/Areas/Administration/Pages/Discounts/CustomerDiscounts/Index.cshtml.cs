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

        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication)
        {          
            _customerDiscountApplication = customerDiscountApplication;
        }
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

    }
}
