using Microsoft.AspNetCore.Mvc;

namespace Inori.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}