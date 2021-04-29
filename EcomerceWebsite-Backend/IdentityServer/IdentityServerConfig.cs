using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace EcomerceWebsite_Backend.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("ecommerce.customer.api", "Rookie Shop API")
             };

        public static IEnumerable<Client> GetClients(IConfiguration configuration) {
          return  new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "ecommerce.customer.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = {configuration["IdentityDbConfig:MVC:RedirectUris"]},


                    PostLogoutRedirectUris = {configuration["IdentityDbConfig:MVC:PostLogoutRedirectUris"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerce.customer.api"
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           {configuration["IdentityDbConfig:Swagger:RedirectUris"] },
                    PostLogoutRedirectUris = {configuration["IdentityDbConfig:Swagger:PostLogoutRedirectUris"] },
                    AllowedCorsOrigins =     { configuration["IdentityDbConfig:Swagger:AllowedCorsOrigins"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ecommerce.customer.api"
                    }
                },
            };
        }
            
    }
}
