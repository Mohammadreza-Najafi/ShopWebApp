using ShopManagement.Application.Contracts.Order;

namespace _01_ShopQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);


    }
}
