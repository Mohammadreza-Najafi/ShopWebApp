using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slide;

namespace ShopWebApp.Areas.Administration.Pages.Shop.Slides
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateSlide Slide { get; set; }

        private readonly ISlideApplication _slideApplication;
        public CreateModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        //public IActionResult OnGet()
        //{
        //    //var command = new CreateSlide();

        //    //return Partial("./Create", command);
        //}

        public IActionResult OnPost()
        {
            _slideApplication.Create(Slide);
            return RedirectToPage("./Index");
          
        }
    }
}
