using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Models
{
    public class ItemCarrinhoDTO
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }
    }
}
