using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Inventory
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditInventory Inventory { get; set; }
        public List<ProductViewModel> Products { get; set; }

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Inventory = _inventoryApplication.GetDetails(id);
            Products = _productApplication.GetProducts();
        }

        public IActionResult OnPost(EditInventory inventory)
        {
            _inventoryApplication.Edit(inventory);
            return RedirectToPage("./Index");
        }
    }
}
