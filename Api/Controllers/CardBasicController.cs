using Microsoft.AspNetCore.Mvc;

namespace dotnet_admin_dashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardBasicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Would render: content.cards.cards-basic");
        }
    }
}
