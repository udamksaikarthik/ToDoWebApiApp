using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Identity services:
        // - UserManager handles user CRUD, password hashing/verification, user-role lookup.
        // - RoleManager handles role CRUD.
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            // Basic guard: ensure password confirmation matches.
            if (model.Password != model.ConfirmPassword)
                return BadRequest("Passwords do not match.");

            // Create new Identity user record (password will be hashed by Identity internals).
            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
            var createResult = await _userManager.CreateAsync(user, model.Password);

            if (!createResult.Succeeded)
            {
                return BadRequest(createResult.Errors);
            }

            // Auto-assign every new account to "User" role.
            // Roles are seeded at startup (Program.cs), so no public API is needed for role creation.
            var assignResult = await _userManager.AddToRoleAsync(user, "User");
            if (!assignResult.Succeeded)
            {
                return BadRequest(assignResult.Errors);
            }
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            // Step 1: locate the user and verify password hash.
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // Step 2: load role memberships (User/Admin/etc.) to include in JWT claims.
                var userRoles = await _userManager.GetRolesAsync(user);

                // Step 3: create base claims for the token.
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Step 4: append role claims so [Authorize(Roles = "...")] can work.
                authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                // Step 5: issue signed JWT token.
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                        SecurityAlgorithms.HmacSha256)); ;

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            // Username/password invalid -> 401.
            return Unauthorized();
        }
    }
}
