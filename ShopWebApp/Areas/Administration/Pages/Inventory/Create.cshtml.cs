using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Inventory
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateInventory Inventory{ get; set; }
        public List<ProductViewModel> Products { get; set; }

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet()
        {
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost(CreateInventory inventory)
        {
            _inventoryApplication.Create(inventory);
            return RedirectToPage("./Index");
        }

    }
}
