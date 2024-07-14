using DiscountManagement.Application.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditColleagueDiscount ColleagueDiscount { get; set; }
        public List<ProductViewModel> Products { get; set; }

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;

        }

        public void OnGet(long id)
        {
            ColleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost()
        {
            _colleagueDiscountApplication.Edit(ColleagueDiscount);

            return RedirectToPage("./Index");
        }
    }
}
