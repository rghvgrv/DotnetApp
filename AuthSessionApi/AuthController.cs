using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    // Endpoint for user login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Validate user credentials (replace with real validation)
        if (request.Username == "user" && request.Password == "password")
        {
            // Set session data
            HttpContext.Session.SetString("Username", request.Username);

            // Create authentication cookie
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Username) };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok("Logged in successfully");
        }

        return Unauthorized("Invalid credentials");
    }

    // Endpoint for user logout
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return Ok("Logged out successfully");
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
