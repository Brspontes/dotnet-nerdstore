using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NerdStore.Enterprise.Web.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
