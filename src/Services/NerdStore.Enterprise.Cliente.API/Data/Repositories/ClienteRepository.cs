using Microsoft.EntityFrameworkCore;
using NerdStore.Enterprise.Cliente.API.Models;
using NerdStore.Enterprise.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Cliente.API.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext context;

        public ClienteRepository(ClientesContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public void Adicionar(Models.Cliente cliente)
        {
            context.Clientes.Add(cliente);
        }

        public async Task<Models.Cliente> ObterPorCpf(string cpf)
        {
            return await context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Models.Cliente>> ObterTodos()
        {
            return await context.Clientes.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
