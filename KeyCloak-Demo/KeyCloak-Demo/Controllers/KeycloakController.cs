using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeyCloak_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeycloakController : Controller
    {
        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            return Ok("Token valid");
        }
    }
}
