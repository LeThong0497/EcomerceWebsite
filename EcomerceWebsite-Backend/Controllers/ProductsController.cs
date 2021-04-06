using EcomerceWebsite_Backend.Data;
using EcomerceWebsite_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceWebsite_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts()
        {
            var products = await _applicationDbContext.Products.Include("Images").Select(x =>
                new
                {
                    x.ProductID,
                    x.Name,
                    x.Price,
                    x.CPU,
                    x.Quantity,
                    x.Screen,
                    x.HardDrive,
                    x.Card,
                    x.GateWay,
                    x.Size,
                    x.Images
                }).ToListAsync();

            var prodVMs = products.Select(x =>
                            new ProductVm
                            {
                                ProductId = x.ProductID,
                                Name = x.Name,
                                Price = x.Price,
                                CPU=x.CPU,
                                Quantity=x.Quantity,
                                Screen=x.Screen,
                                HardDrive=x.HardDrive,
                                Card=x.Card,
                                GateWay=x.GateWay,
                                Size=x.Size,
                                Image = x.Images.Select(x => x.ImageName).ToList()
                            }).ToList();

            return prodVMs;
        }
    }
}
