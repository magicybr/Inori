using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Inori.IdentityApi.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IWebHostEnvironment env)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}