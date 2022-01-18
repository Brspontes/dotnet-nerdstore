using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Web.Services;
using System;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService catalogoService;
        //private readonly ICatalogoServiceRefit catalogoServiceRefit;

        public CatalogoController(ICatalogoService catalogoService)
        {
            this.catalogoService = catalogoService;
            //this.catalogoServiceRefit = catalogoServiceRefit;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            var produtos = await catalogoService.ObterTodos();
            return View(produtos);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var produto = await catalogoService.ObterPorId(id);
            return View(produto);
        }
    }
}
