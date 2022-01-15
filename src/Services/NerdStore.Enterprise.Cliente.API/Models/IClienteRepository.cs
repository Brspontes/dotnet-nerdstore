using NerdStore.Enterprise.Core.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Cliente.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
