using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class ProductMenuViewComponent : ViewComponent
    {
        private readonly IProductClient _productClient;

        public ProductMenuViewComponent(IProductClient brandApiClient)
        {
            _productClient = brandApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Products = await _productClient.GetProduct();

            return View(Products);
        }

        
    }
}
