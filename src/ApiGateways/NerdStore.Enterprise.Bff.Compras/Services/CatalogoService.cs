using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Bff.Compras.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Services
{
    public interface ICatalogoService
    {
    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }
    }
}
