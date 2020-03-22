using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ONKDelprojekt1Frontend.Data;
using ONKDelprojekt1Frontend.Validators;

namespace ONKDelprojekt1Frontend
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            CurrentEnvironment = env;
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{CurrentEnvironment.EnvironmentName}.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient<IToolService, ToolService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "text/json");
            });
            services.AddHttpClient<ICraftsManService, CraftsmanService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "text/json");
                
            });
            services.AddHttpClient<IToolboxService, ToolboxService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "text/plain");
            });

            services.AddValidatorsFromAssemblyContaining<ToolValidator>();
            services.AddValidatorsFromAssemblyContaining<ToolBoxValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the client request pipeline.
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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
