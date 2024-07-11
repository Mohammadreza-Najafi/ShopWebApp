
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class IndexModel : PageModel
    {
        public List<ColleagueDiscountViewModel> ColleagueDiscounts { get; set; }

        //[TempData]
        //public string Message { get; set; }
        //public ProductSearchModel SearchModel { get; set; }

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication)
        { 
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }
        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetRemove(long id)
        {
            _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
