﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NerdStore.Enterprise.WebAPI.Core.Identidade;
using NerdStore.Enterprise.WebAPI.Core.Usuario;
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;

namespace NerdStore.Enterprise.Identidade.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IAspNetUser, AspNetUser>();
            return services;
        }

        public static IApplicationBuilder AddApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseJwksDiscovery();

            return app;
        }
    }
}