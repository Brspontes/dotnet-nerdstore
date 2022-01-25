using MediatR;
using NerdStore.Enterprise.Core.Messages.Integration;
using NerdStore.Enterprise.MessageBus;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Pedido.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            this.bus = bus;
        }

        public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await bus.PublishAsync(new PedidoRealizadoIntegrationEvent(message.ClienteId));
        }
    }
}
