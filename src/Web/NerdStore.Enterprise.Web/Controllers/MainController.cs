using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Web.Models;
using System.Linq;

namespace NerdStore.Enterprise.Web.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any())
            {
                return true;
            }
            return false;
        }
    }
}
