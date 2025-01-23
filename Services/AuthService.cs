using EMR_Final.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMR_Final.Services
{
    public class AuthService
    {
        private readonly EMRDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(EMRDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // Check if the user exists
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.username == username && u.isactive);
            if (user == null) return "Invalid username";

            // Password check (hashed passwords should be used)
            if (user.passwordhash != password) return "Invalid password";

            // Generate JWT Token
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.userid.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, user.role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:ExpirationInHours"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
