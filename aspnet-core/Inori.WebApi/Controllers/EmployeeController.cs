using Inori.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inori.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeController(IHttpContextAccessor httpContextAccessor, ICurrentUser currentUser)
        {
            var user = httpContextAccessor.HttpContext.User;
            this._currentUser = currentUser;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}