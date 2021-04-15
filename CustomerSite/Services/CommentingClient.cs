using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShareViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public class CommentingClient : ICommentingClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentingClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> PostCommenting(CommentingVm commentingVm)
        {
            var client = _httpClientFactory.CreateClient("local");
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(commentingVm),
               Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Commenting",httpContent);

            return response.EnsureSuccessStatusCode();
            
        }

       
    }
}
