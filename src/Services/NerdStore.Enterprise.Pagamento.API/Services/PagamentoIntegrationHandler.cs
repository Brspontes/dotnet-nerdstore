using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Pagamento.API.Services
{
    public class PagamentoIntegrationHandler : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
