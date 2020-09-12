using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webapi_tokenauth.Models;

namespace webapi_tokenauth.services{
    public class AuthRepository{

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        private string CreateToken(User user)
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
                Issuer =_configuration.GetSection("Jwt:Issuer").Value,
                Audience= _configuration.GetSection("Jwt:Audience").Value,
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        // public async Task<ServiceResponse<string>> Login(string username, string password)
        // {
        //     ServiceResponse<string> response = new ServiceResponse<string>();
        //     User user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
        //     if (user == null)
        //     {
        //         response.Success = false;
        //         response.Message = "User not found.";
        //     }
        //     else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //     {
        //         response.Success = false;
        //         response.Message = "Wrong password.";
        //     }
        //     else
        //     {
        //         response.Data = CreateToken(user);
        //     }
        //     return response;
        // }


    }
}