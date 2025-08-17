using Microsoft.AspNetCore.Mvc;

namespace laravel_admin_template.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfectScrollbarController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Would render: content.extended-ui.extended-ui-perfect-scrollbar");
        }
    }
}
