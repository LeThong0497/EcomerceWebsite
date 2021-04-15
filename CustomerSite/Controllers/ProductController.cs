using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductClient _productApiClient;
        private readonly IConfiguration _configuration;

        public ProductController(IProductClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productApiClient.GetProducts();

            return View(products);
        }

        public async Task<IActionResult> GetProductByBrand(int id)
        {
            var products = await _productApiClient.GetProductsByBrand(id);

            return View(products);
        }
       
        
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productApiClient.GetProduct(id);

            return View(product);
        }

    }
}
