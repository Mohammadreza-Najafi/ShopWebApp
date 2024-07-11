using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopWebApp.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public DefineColleagueDiscount ColleagueDiscount { get; set; }
        public List<ProductViewModel> Products { get; set; }

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
           
        }
        public void OnGet()
        {
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost()
        {
            _colleagueDiscountApplication.Define(ColleagueDiscount);

            return RedirectToPage("./Index");
        }

    }
}
