using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Payments.Domain;
using Payments.Domain.Repository.Interfaces;
using Payments.Web.Data;
using Payments.Web.Services;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)

        {

            services.AddAuthentication("Identity.Application")
                .AddCookie();
           
            //services.AddAutoMapper(typeof(UserModelProfile));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient<IFinalBillService, FinalBillService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44387/");
            });
            services.AddHttpClient<IStatusFinalBillService, StatusFinalBillService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44387/");
            });
            services.AddHttpClient<IStatusPaymentSolutionService, StatusPaymentSolutionService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44387/");
            });
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
                app.UseExceptionHandler("/Error");
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
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
