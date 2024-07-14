using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopWebApp.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public IndexModel(IProductApplication ProductApplication, IProductPictureApplication ProductPictureApplication)
        {
            _productApplication = ProductApplication;
            _productPictureApplication = ProductPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _productPictureApplication.Search(searchModel);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

        //    Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

           // Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
