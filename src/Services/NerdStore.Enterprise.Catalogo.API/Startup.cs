using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NerdStore.Enterprise.Catalogo.API.Configuration;
using NerdStore.Enterprise.Catalogo.API.Data;
using NerdStore.Enterprise.Catalogo.API.Data.Repositories;
using NerdStore.Enterprise.Catalogo.API.Models;
using NerdStore.Enterprise.WebAPI.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Catalogo.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(environment.ContentRootPath)
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                  .AddEnvironmentVariables();

            //if (environment.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);
            services.AddJwtConfiguration(Configuration);
            services.AddSwaggerConfiguration();
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(env);
        }
    }
}
