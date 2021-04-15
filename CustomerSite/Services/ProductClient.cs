using ShareViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public class ProductClient : IProductClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("local");
            var response = await client.GetAsync("/api/Products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<IList<ProductVm>> GetProductsByBrand(int id)
        {
            var client = _httpClientFactory.CreateClient("local");
            var response = await client.GetAsync($"/api/Products/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<ProductVm> GetProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("local");
            var response = await client.GetAsync($"/api/Products/Product/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductVm>();
        }
    }
}
