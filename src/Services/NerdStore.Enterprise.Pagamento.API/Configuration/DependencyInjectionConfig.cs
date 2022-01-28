using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Pagamento.API.Data;
using NerdStore.Enterprise.Pagamento.API.Data.Repository;
using NerdStore.Enterprise.Pagamento.API.Facade;
using NerdStore.Enterprise.Pagamento.API.Models;
using NerdStore.Enterprise.Pagamento.API.Services;
using NerdStore.Enterprise.WebAPI.Core.Usuario;

namespace NerdStore.Enterprise.Pagamento.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}
