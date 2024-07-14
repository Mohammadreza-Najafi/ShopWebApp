using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slide;

namespace ShopWebApp.Areas.Administration.Pages.Shop.Slides
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditSlide Slide { get; set; }

        private readonly ISlideApplication _slideApplication;
        public EditModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(long id)
        {
            Slide = _slideApplication.GetDetails(id);
        }
        public IActionResult OnPost()
        {
            _slideApplication.Edit(Slide);

            return RedirectToPage("./Index");
        }
    }
}
