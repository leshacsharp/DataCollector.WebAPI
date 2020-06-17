using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataCollector.WebAPI.Context;
using DataCollector.WebAPI.Models.Interfaces;
using DataCollector.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DataCollector.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("MongoDbConnection");

            services.AddScoped<IDbContext, DataCollectorContext>(p => new DataCollectorContext(connectionString));
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();
            services.AddAuthentication().AddMicrosoftAccount(options =>
            {
                options.ClientId = Configuration.GetValue<string>("Authentication:ClientId");
                options.ClientSecret = Configuration.GetValue<string>("Authentication:ClientSecret");
            });
       
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            services.AddHttpClient();
            services.AddScoped<HttpClient>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
