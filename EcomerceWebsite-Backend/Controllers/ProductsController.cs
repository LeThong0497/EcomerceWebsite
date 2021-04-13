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
            var products = await _applicationDbContext.Products.Include("Images").Include("Comments").Select(x =>
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
                    x.BrandID,
                    x.Images,
                    x.Comments
                }).ToListAsync();

            var prodVMs = products.Select(x =>
                            new ProductVm
                            {
                                ProductId = x.ProductID,
                                Name = x.Name,
                                Price = x.Price,
                                CPU =x.CPU,
                                Quantity=x.Quantity,
                                Screen=x.Screen,
                                HardDrive=x.HardDrive,
                                Card=x.Card,
                                GateWay=x.GateWay,
                                Size=x.Size,
                                BrandID=x.BrandID,
                                Images = x.Images.Select(x => x.ImageName).ToList(),
                                Commentings = x.Comments.Select(x=>new CommentingVm {star=x.Star}).ToList()
                            }).ToList();

            return prodVMs;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductsByBrand(int id)
        {
            var products = await _applicationDbContext.Products.Where(x => x.BrandID==id).Include("Images").Include("Comments").Select(x =>
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
                    x.BrandID,
                    x.Images,
                    x.Comments
                }).ToListAsync();

            var prodVMs = products.Select(x =>
                            new ProductVm
                            {
                                ProductId = x.ProductID,
                                Name = x.Name,
                                Price =x.Price,
                                CPU = x.CPU,
                                Quantity = x.Quantity,
                                Screen = x.Screen,
                                HardDrive = x.HardDrive,
                                Card = x.Card,
                                GateWay = x.GateWay,
                                Size = x.Size,
                                BrandID=x.BrandID,
                                Images = x.Images.Select(x => x.ImageName).ToList(),
                                Commentings = x.Comments.Select(x => new CommentingVm {  star = x.Star,
                                                                                         date=x.Date,
                                                                                         content=x.Content,
                                                                                         userName=x.UserName }).ToList()
                            }).ToList();

            return prodVMs;
        }

        [HttpGet("Product/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct (int id)
        {
            var product = await _applicationDbContext.Products.Include("Images").Include("Comments").Where(x => x.ProductID == id).FirstAsync();
                  
            if(product==null)
            {
                return NotFound();
            }

            var prodVM = new ProductVm();

            prodVM.ProductId = product.ProductID;
            prodVM.Name = product.Name;
            prodVM.Price = product.Price;
            prodVM.CPU = product.CPU;
            prodVM.Quantity = product.Quantity;
            prodVM.Screen = product.Screen;
            prodVM.HardDrive = product.HardDrive;
            prodVM.Card = product.Card;
            prodVM.GateWay = product.GateWay;
            prodVM.Size = product.Size;
            prodVM.BrandID = product.BrandID;
            prodVM.Images = product.Images.Select(x => x.ImageName).ToList();
            prodVM.Commentings = product.Comments.Select(x => new CommentingVm {
                                                                                star = x.Star,
                                                                                date = x.Date,
                                                                                content = x.Content,
                                                                                userName = x.UserName
                                                                            }).ToList();

            return prodVM;
        }
    }
}
