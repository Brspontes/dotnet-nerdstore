using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Controllers
{
    public class IdentidadeController : Controller
    {
        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            // API Login

            if (false) return View(usuarioRegistro);

            // Realizar Login

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            // API Login

            if (false) return View(usuarioLogin);

            // Realizar Login

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
