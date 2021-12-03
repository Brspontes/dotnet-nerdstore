using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Web.Services;

namespace NerdStore.Enterprise.Web.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        }
    }
}
