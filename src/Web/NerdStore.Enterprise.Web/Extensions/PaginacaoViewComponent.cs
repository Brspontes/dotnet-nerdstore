using Microsoft.AspNetCore.Mvc;
using NerdStore.Enterprise.Web.Models;

namespace NerdStore.Enterprise.Web.Extensions
{
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList modeloPaginado)
        {
            return View(modeloPaginado);
        }
    }
}
