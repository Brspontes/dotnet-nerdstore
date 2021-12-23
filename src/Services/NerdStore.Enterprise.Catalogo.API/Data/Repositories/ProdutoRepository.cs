using Microsoft.EntityFrameworkCore;
using NerdStore.Enterprise.Catalogo.API.Models;
using NerdStore.Enterprise.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Catalogo.API.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext context;

        public ProdutoRepository(CatalogoContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Produto produto)
        {
            context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            context.Produtos.Update(produto);
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
