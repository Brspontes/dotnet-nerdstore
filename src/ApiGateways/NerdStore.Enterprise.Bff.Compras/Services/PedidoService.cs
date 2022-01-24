using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Bff.Compras.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Services
{
    public interface IPedidoService
    {
    }

    public class PedidoService : Service, IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
        }
    }
}
