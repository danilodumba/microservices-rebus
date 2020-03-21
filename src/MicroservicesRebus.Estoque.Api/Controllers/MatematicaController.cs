using Microsoft.AspNetCore.Mvc;

namespace MicroservicesRebus.Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatematicaController : ControllerBase
    {
        [HttpPost("soma")]
        public IActionResult Soma(decimal x, decimal y)
        {
            return Ok();
        }
    }
}