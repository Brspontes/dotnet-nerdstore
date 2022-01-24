using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Bff.Compras.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Services
{
    public interface IPagamentoService
    {
    }

    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}
