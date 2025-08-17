using Microsoft.AspNetCore.Mvc;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForgotPasswordBasicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Would render: content.authentications.auth-forgot-password-basic");
        }
    }
}
