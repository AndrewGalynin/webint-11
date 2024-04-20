using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _6lr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;
        static readonly PasswordEncryptionService encryptionService = new PasswordEncryptionService();

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _usersService.GetUsers();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Users user)
        {
            await _usersService.AddUser(user);
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _usersService.GetUserByEmail(login.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email");
            }

            if (!PasswordMatches(login.Password, user.Password))
            {
                return Unauthorized("Invalid password");
            }
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }
        private bool PasswordMatches(string enteredPassword, string hashedPassword)
        {
            return hashedPassword == encryptionService.EncryptPassword(enteredPassword);
        }
        private string GenerateJwtToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Z2O029dM9lMSl6oTqt5TVPiOBa44onNiRsMOh9qtQ518dLdUhUI2E3bV196j8C3cArPIyJ5vwHIUxhsqmDec6cW64phvbrv3wCiA1McChZi5NPDWiMIc0lk13Mf8sic8CP8OGPKE2fJDEQa7j98Ur3IE7ki1j6uHn1WaJTzluyn16P7KSotasofXJTKWA7NB2JPaoKwQgFXiZHGYMW7jp1O7HTpuo6nVzL86MyEqBt83VkKXVYMXhSdsQ6"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "MyIssuer",
                audience: "MyAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}