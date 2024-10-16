using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("secure")]
[Authorize] // Ensure this controller requires authentication
public class SecureController : ControllerBase
{
    // Secure endpoint that retrieves session information
    [HttpGet("data")]
    public IActionResult GetSecureData()
    {
        // Retrieve username from session
        var username = HttpContext.Session.GetString("Username");

        if (username == null)
        {
            return Unauthorized("User session not found.");
        }

        return Ok($"This is a secure endpoint. Hello, {username}!");
    }
}
