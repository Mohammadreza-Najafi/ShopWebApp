﻿using Microsoft.AspNetCore.Mvc;

namespace ShopWebApp.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
    
}