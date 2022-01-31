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

        public async Task<PagedViewModel<ProdutoViewModel>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            var response = await httpClient.GetAsync($"/catalogo/produtos?ps={pageSize}&page={pageIndex}&q={query}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<PagedViewModel<ProdutoViewModel>>(response);
        }
    }
}
