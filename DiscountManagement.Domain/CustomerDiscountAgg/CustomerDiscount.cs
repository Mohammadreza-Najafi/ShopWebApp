using _0_Framwork.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate {  get; private set; }
        public DateTime EndDate { get; private set; }

        public CustomerDiscount(long productId, string name, int discountRate,
                    DateTime startDate, DateTime endDate)
        {
            ProductId = productId;
            Name = name;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Edit(long productId, string name, int discountRate,
                 DateTime startDate, DateTime endDate)
        {
            ProductId = productId;
            Name = name;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
