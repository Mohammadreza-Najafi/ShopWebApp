using _01_ShopQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApp.ViewComponents;

public class MenuViewComponent : ViewComponent
{
    private readonly IProductCategoryQuery _productCategoryQuery;

    public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
    {
        _productCategoryQuery = productCategoryQuery;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}