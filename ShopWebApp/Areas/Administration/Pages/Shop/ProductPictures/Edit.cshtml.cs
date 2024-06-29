using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopWebApp.Areas.Administration.Pages.Shop.ProductPictures
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProductPicture ProductPicture { get; set; }
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public List<ProductViewModel> Products;
        public EditModel(IProductApplication ProductApplication, IProductPictureApplication ProductPictureApplication)
        {
            _productApplication = ProductApplication;
            _productPictureApplication = ProductPictureApplication;
        }

        public void OnGet(long id)
        {
            ProductPicture = _productPictureApplication.GetDetails(id);
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost()
        {
            _productPictureApplication.Edit(ProductPicture);
            return RedirectToPage("./Index");

        }
    
    }
}
