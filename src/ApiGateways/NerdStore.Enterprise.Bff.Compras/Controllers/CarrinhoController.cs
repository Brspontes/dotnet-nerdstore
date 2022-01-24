using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Bff.Compras.Services;
using NerdStore.Enterprise.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Bff.Compras.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly ICarrinhoService carrinhoService;
        private readonly ICatalogoService catalogoService;

        public CarrinhoController(ICarrinhoService carrinhoService, ICatalogoService catalogoService)
        {
            this.carrinhoService = carrinhoService;
            this.catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("compras/carrinho")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }

        [HttpGet]
        [Route("compras/carrinho-quantidade")]
        public async Task<IActionResult> ObterQuantidadeCarrinho()
        {
            return CustomResponse();
        }

        [HttpPost]
        [Route("compras/carrinho/items")]
        public async Task<IActionResult> AdicionarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpPut]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpDelete]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho()
        {
            return CustomResponse();
        }
    }
}
