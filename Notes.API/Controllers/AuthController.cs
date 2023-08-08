using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        
        [HttpGet("login")]
        public string Get(string email, string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Country, "turkey"),
                
                new Claim(JwtRegisteredClaimNames.Email, email)
            };
            var singninKey = "bubenimsigninkeyim";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(singninKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer:"http://www.yasineren.com",
                audience:"mysecuritykey",
                claims:claims,
                expires:DateTime.Now.AddDays(15),
                notBefore:DateTime.Now,
                signingCredentials:credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
       
            return token;
        }
        
    }
}
