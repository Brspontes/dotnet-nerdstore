using NerdStore.Enterprise.Core.Communication;
using NerdStore.Enterprise.Web.Models;
using System;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Services
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    }
}
