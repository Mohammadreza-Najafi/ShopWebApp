using _0_Framwork.Infrastructure;
using DiscountManagement.Application.Contract;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    
    public class CustomerDiscountRepository : RepositoryBase<long,CustomerDiscount> , ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context ,ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Name = x.Name,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id,x.Name}).ToList();

            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id=x.Id,
                ProductId =x.ProductId,
                Name = x.Name,
                DiscountRate =x.DiscountRate,
                StartDate=x.StartDate.ToString(),
                EndDate=x.EndDate.ToString(),
                CreationDate = x.CreationDate.ToString()

            });

            if(searchModel.ProductId > 0) 
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }


            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discount =>
                discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);


            return discount;

        }
    }
}
