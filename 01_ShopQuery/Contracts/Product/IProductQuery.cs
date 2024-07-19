﻿
namespace _01_ShopQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
        
        List<ProductQueryModel> Search(string value);
    }
}
