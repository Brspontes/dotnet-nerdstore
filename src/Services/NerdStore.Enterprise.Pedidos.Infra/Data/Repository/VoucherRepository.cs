using Microsoft.EntityFrameworkCore;
using NerdStore.Enterprise.Core.Data;
using NerdStore.Enterprise.Pedidos.Domain.Vouchers;
using NerdStore.Enterprise.Pedidos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Pedidos.Infra.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext context;

        public VoucherRepository(PedidosContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public void Atualizar(Voucher voucher)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo) =>
            await context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
    }
}
