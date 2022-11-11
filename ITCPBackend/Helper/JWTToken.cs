using ITCPBackend.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;

namespace ITCPBackend.Helper
{
    public class JWTToken
    {
        public static string Generate(Users userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salskmiddcmio32##8936@#"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        new Claim("role", userInfo.role)
    };



            var token = new JwtSecurityToken("localhost", "localhost", claims,
                expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
