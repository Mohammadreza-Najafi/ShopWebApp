﻿using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using _01_ShopQuery.Contracts;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contracts.Order;

namespace _01_ShopQuery.Query
{
    public class CartCalculaterService : ICartCalculatorService
    {
        private readonly IAuthHelper _authHelper;
        private readonly DiscountContext _discountContext;

        public CartCalculaterService(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();

            var colleagueDiscounts = _discountContext.ColleagueDiscounts
                .Where(x => !x.IsRemoved)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();

            var customerDiscounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();

            var currentAccountRole = _authHelper.CurrentAccountRole();

            foreach (var cartItem in cartItems)
            {

                if (currentAccountRole == Roles.ColleagueUser)
                {
                    var colleagueDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (colleagueDiscount != null)
                        cartItem.DiscountRate = colleagueDiscount.DiscountRate;
                }
                else
                {
                    var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                    if (customerDiscount != null)
                        cartItem.DiscountRate = customerDiscount.DiscountRate;

                }


                cartItem.DiscountAmount = ((cartItem.TotalItemPrice * cartItem.DiscountRate) / 100);
                cartItem.ItemPayAmount = cartItem.TotalItemPrice - cartItem.DiscountAmount;

                cart.Add(cartItem);
            }

            return cart;
        }
    }
}
