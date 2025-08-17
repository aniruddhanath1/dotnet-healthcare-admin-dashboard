using Microsoft.AspNetCore.Mvc;

namespace laravel_admin_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterBasicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Would render: content.authentications.auth-register-basic");
        }
    }
}
