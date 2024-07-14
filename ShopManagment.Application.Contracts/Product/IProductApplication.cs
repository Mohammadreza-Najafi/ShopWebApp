﻿using _0_Framwork.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);

        OperationResult Edit(EditProduct command);

        OperationResult IsStock(long id);
        OperationResult NotInStock(long id);

        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);

    }
}