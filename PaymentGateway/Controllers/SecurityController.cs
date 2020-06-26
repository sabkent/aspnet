using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PaymentGateway.Controllers
{
    [Route("security")]
    public class SecurityController : Controller
    {
        [HttpPost, Route("token")]
        public async Task<IActionResult> Token()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "testMerchant")
            };

            var secretBytes = Encoding.UTF8.GetBytes(SecurityConstants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                SecurityConstants.Issuer,
                SecurityConstants.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = accessToken });
        }
    }
}
