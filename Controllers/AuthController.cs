using EMR_Final.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMR_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var token = await _authService.LoginAsync(loginRequest.Username, loginRequest.Password);

            if (token.Contains("Invalid"))
                return Unauthorized(new { message = token });

            return Ok(new { token });
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // Logout logic if necessary (e.g., token invalidation in future)
            return Ok(new { message = "Logged out successfully" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
