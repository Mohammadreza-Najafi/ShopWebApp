
namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { set; get; }
        public string CreationDate { get; set; }
        public long ProductsCount { get; set; }
    }
}
