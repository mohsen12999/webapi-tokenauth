using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_tokenauth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace webapi_tokenauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        private string GenerateJWTToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JWT:SecretKey").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = _configuration.GetSection("Jwt:Issuer").Value,
                Audience = _configuration.GetSection("Jwt:Audience").Value,
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var this_user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username); //await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (this_user == null)
            {
                return NotFound();
            }

            var passwordHasher = new PasswordHasher<User>();

            if(passwordHasher.VerifyHashedPassword(this_user,this_user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                var tokenString = GenerateJWTToken(this_user);
                return  Ok(new
                {
                    token = tokenString,
                    userDetails = this_user,
                });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(string username, string email, string password)
        {
            try
            {
                var user = new User() { UserName = username, Email = email };
                var passwordHasher = new PasswordHasher<User>();
                var passwordHash = passwordHasher.HashPassword(user, password);
                user.PasswordHash = passwordHash;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                var tokenString = GenerateJWTToken(user);
                return Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpPost("access")]
        public IActionResult Access()
        {
            return Ok(new { msg="access granted" });
        }

    }

}