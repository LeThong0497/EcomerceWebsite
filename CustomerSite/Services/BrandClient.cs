using Microsoft.Extensions.Configuration;
using ShareViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public class BrandClient : IBrandClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BrandClient(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<BrandVm> GetBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Brand/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BrandVm>();
        }

        public async Task<IList<BrandVm>> GetBrands()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<BrandVm>>();
        }
    }
}
