using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Cliente.API.Application.Commands;
using NerdStore.Enterprise.Core.Mediatr;
using NerdStore.Enterprise.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Cliente.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            this.mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await mediatorHandler.EnviarComando(new RegistrarClienteCommand(System.Guid.NewGuid(), "Brian", "brian@hotmail.com", "42071121899"));



            return CustomResponse(resultado);
        }
    }
}
