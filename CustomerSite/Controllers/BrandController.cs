using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandClient _branclient;

        private readonly IConfiguration _configuration;

        public BrandController(IBrandClient brandClient, IConfiguration configuration)
        {
            _branclient = brandClient;
            _configuration = configuration;
        }
       

        public async Task<IActionResult> GetBrand(int id)
        {
            var product = await _branclient.GetBrand(id);

            return View(product);
        }


        public async Task<IActionResult> GetBrands(int id)
        {
            var brands = await _branclient.GetBrands();

            return View(brands);
        }
    }
}
