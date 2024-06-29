using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopWebApp.Areas.Administration.Pages.Shop.ProductPictures
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public CreateProductPicture ProductPicture { get; set; }

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public List<ProductViewModel> Products;
       
        public CreateModel(IProductApplication ProductApplication, IProductPictureApplication ProductPictureApplication)
        {
            _productApplication = ProductApplication;
            _productPictureApplication = ProductPictureApplication;
        }

        public void OnGet()
        {
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost()
        {
           _productPictureApplication.Create(ProductPicture);

            return RedirectToPage("./Index");
        }
    }
}
