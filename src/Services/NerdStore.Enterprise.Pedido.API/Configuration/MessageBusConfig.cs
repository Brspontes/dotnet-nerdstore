using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Enterprise.Core.Utils;
using NerdStore.Enterprise.MessageBus;
using NerdStore.Enterprise.Pedido.API.Services;

namespace NerdStore.Enterprise.Pedido.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                 .AddHostedService<PedidoOrquestradorIntegrationHandler>()
                 .AddHostedService<PedidoIntegrationHandler>();
        }
    }
}
