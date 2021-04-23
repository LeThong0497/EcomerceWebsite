using CustomerSite.Services;
using EcommerceWebsite.CustomerSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Net.Http;

namespace CustomerSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                   // options.Authority = "https://thongrookie.azurewebsites.net/";
                    options.Authority = "https://localhost:44336/";
                
                    options.RequireHttpsMetadata = false;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("ecommerce.customer.api");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });
            services.AddHttpContextAccessor();

            services.AddHttpClient("local", (configureClient) =>
            {
               // configureClient.BaseAddress = new Uri("https://thongrookie.azurewebsites.net/");
                configureClient.BaseAddress = new Uri("https://localhost:44336/");
            })
               .ConfigurePrimaryHttpMessageHandler((serviceProvider) =>
               {
                   var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                   var cookieContainer = new CookieContainer();
                   if (httpContext.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
                   {
                       var identityCookieValue = httpContext.Request.Cookies[".AspNetCore.Identity.Application"];
                       //cookieContainer.Add(new Uri("https://thongrookie.azurewebsites.net/"), new Cookie(".AspNetCore.Identity.Application", identityCookieValue));
                       cookieContainer.Add(new Uri("https://localhost:44336/"), new Cookie(".AspNetCore.Identity.Application", identityCookieValue));
                   }
                   return new HttpClientHandler()
                   {
                       CookieContainer = cookieContainer
                   };
               });

            services.AddTransient<IProductClient, ProductClient>();

            services.AddTransient<IBrandClient, BrandClient>();

            services.AddTransient<ICommentingClient, CommentingClient>();

            services.AddTransient<IRequest, Request>();



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=index}/{id?}");
            });
        }
    }
}
