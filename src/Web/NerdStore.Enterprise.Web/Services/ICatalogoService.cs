using NerdStore.Enterprise.Web.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public interface ICatalogoService
    {
        Task<PagedViewModel<ProdutoViewModel>> ObterTodos(int pageSize, int pageIndex, string query = null);
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }

    public interface ICatalogoServiceRefit
    {
        [Get("/catalogo/produtos/")]
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();

        [Get("/catalogo/produtos/{id}")]
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
