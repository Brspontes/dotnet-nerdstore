using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Catalogo.API.Data;
using NerdStore.Enterprise.Catalogo.API.Data.Repositories;
using NerdStore.Enterprise.Catalogo.API.Models;

namespace NerdStore.Enterprise.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
