namespace ShopManagement.Application.Contracts.Order
{
    public class AddOrderItem
    {
        public long ProductId {  get; private set; }
        public int Count { get; private set; }
        public double UnitPrice { get; private set; }
        public int DiscountRate { get; private set; }

    }
}
