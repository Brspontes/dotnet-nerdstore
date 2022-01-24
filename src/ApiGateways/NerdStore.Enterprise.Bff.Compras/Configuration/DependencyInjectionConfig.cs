using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.WebAPI.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}
