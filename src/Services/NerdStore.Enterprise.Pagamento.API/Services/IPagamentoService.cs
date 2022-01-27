using NerdStore.Enterprise.Core.Messages.Integration;
using System;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Pagamento.API.Services
{
    public interface IPagamentoService
    {
        Task<ResponseMessage> AutorizarPagamento(Models.Pagamento pagamento);
        Task<ResponseMessage> CapturarPagamento(Guid pedidoId);
        Task<ResponseMessage> CancelarPagamento(Guid pedidoId);
    }
}
