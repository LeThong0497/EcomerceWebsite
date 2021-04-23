using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public  interface IRequest
    {
        Task<HttpClient> SendAccessToken();
    }
}
