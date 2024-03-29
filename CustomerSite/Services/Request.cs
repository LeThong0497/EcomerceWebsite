﻿using CustomerSite.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceWebsite.CustomerSite.Services
{
    public class Request : IRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Request(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpClient> SendAccessToken()
        {
            var client = _httpClientFactory.CreateClient("UrlBackend");
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            client.SetBearerToken(accessToken);
            return client;
        }      
    }
}
