using _0_Framwork.Infrastructure;
using AccountMangement.Infrastructure.EFCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly AccountContext _accountContext;
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext = null, AccountContext accountContext = null) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperationlog(long inventoryId)
        {
            //var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();

            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);

            return inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToString(),
                Operator = "admin",
                OperatorId = x.OperatorId,
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();

          
            //var operations = inventory.Operations.Select(x => new InventoryOperationViewModel
            //{
            //    Id = x.Id,
            //    Count = x.Count,
            //    CurrentCount = x.CurrentCount,
            //    Description = x.Description,
            //    Operation = x.Operation,
            //    OperationDate = x.OperationDate.ToString(),
            //    OperatorId = x.OperatorId,
            //    OrderId = x.OrderId
            //}).OrderByDescending(x => x.Id).ToList();

            //foreach (var operation in operations)
            //{
            //    operation.Operator = accounts.FirstOrDefault(x => x.Id == operation.OperatorId)?.Fullname;
            //}

            //return operations;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var Products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateInventoryCount(),
                CreationDate = x.CreationDate.ToString()
               
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item =>
                item.Product = Products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);

            return inventory;
        }


    }



}
