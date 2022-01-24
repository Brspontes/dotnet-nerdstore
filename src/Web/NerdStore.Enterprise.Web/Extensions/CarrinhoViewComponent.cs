using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Web.Models;
using NerdStore.Enterprise.Web.Services;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _carrinhoService;

        public CarrinhoViewComponent(IComprasBffService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterQuantidadeCarrinho());
        }
    }
}
