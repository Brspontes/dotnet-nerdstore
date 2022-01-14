using NerdStore.Enterprise.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
