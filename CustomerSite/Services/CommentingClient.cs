using EcommerceWebsite.CustomerSite.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShareViewModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public class CommentingClient : ICommentingClient
    {
        private readonly IRequest _request;

        public CommentingClient(IRequest request)
        {
            _request = request;
        }

        public async Task<HttpResponseMessage> PostCommenting(CommentingVm commentingVm)
        {
            var client = _request.SendAccessToken().Result;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(commentingVm),
               Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Commenting",httpContent);

            return response.EnsureSuccessStatusCode();
            
        }

       
    }
}
