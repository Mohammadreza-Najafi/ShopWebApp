using _0_Framework.Application.ZarinPal;
using _01_ShopQuery.Contracts;
using _01_ShopQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ShopWebApp.Pages
{
    public class CheckoutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IOrderApplication _orderApplication;

        public CheckoutModel(ICartCalculatorService cartCalculatorService, ICartService cartService,
            IProductQuery productQuery, IOrderApplication orderApplication)
        {
            Cart = new Cart();
            _cartCalculatorService = cartCalculatorService;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
            }

            Cart = _cartCalculatorService.ComputeCart(cartItems);

            _cartService.Set(Cart);

        }

        public IActionResult OnGetPay()
        {
            var cart = _cartService.Get();

            var result = _productQuery.CheckInventoryStatus(cart.Items);

            if(result.Any(x => !x.IsInStock))
            {
                return RedirectToPage("/Cart");
            }

            var orderId = _orderApplication.PlaceOrder(cart);

            var statusPayment = true;

            var paymentResult = new PaymentResult();

            if (statusPayment)
            {
                var issueTrackingNo = _orderApplication.PaymentSucceeded(orderId, 4515455);

                Response.Cookies.Delete("cart-items");

                paymentResult = paymentResult.Succeeded("succession payment", issueTrackingNo);
                return RedirectToPage("/PaymentResult", paymentResult);
            }


            paymentResult = paymentResult.Failed("Failed Pay - no Pay");

            return RedirectToPage("/PaymentResult", paymentResult);

        }
    }
}
