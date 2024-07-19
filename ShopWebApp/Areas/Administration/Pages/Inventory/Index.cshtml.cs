using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ShopWebApp.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        public List<InventoryViewModel> Inventory { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public InventorySearchModel SearchModel { get; set; }

        //[TempData]
        //public string Message { get; set; }

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication inventoryApplication , IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }
        
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = _productApplication.GetProducts();
            Inventory = _inventoryApplication.Search(searchModel);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };

            return Partial("Increase",command);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);

            return new JsonResult(result);
        }


        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };

            return Partial("Reduce", command);
        }

        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log = _inventoryApplication.GetOperationLog(id);

            return Partial("OperationLog",log);
        }

    }
}
