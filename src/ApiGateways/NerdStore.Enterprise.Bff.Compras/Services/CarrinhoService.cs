using Microsoft.Extensions.Options;
using NerdStore.Enterprise.Bff.Compras.Extensions;
using NerdStore.Enterprise.Bff.Compras.Models;
using NerdStore.Enterprise.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Services
{
    public interface ICarrinhoService
    {
        Task<CarrinhoDTO> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO carrinho);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher);
    }

    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO carrinho)
        {
            throw new NotImplementedException();
        }

        public Task<CarrinhoDTO> ObterCarrinho()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
