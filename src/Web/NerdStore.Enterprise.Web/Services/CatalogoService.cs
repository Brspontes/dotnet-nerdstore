using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Web.Extensions;
using NerdStore.Enterprise.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> options)
        {
            httpClient.BaseAddress = new Uri(options.Value.CatalogoUrl);
            this.httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await httpClient.GetAsync($"/catalogo/produtos/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ProdutoViewModel>(response);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await httpClient.GetAsync($"/catalogo/produtos/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response);
        }
    }
}
