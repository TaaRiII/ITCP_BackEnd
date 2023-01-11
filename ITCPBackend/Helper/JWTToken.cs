using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
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
        new Claim("id", userInfo.Id.ToString())
    };



            var token = new JwtSecurityToken("localhost", "localhost", claims,
                expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string ClientGenerate(Client userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salskmiddcmio32##8936@#"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        new Claim("id", userInfo.Id.ToString())
    };



            var token = new JwtSecurityToken("localhost", "localhost", claims,
                expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public bool IsTokenValid { get; private set; }
        //public bool IsMaster { get; set; }
        //public string Error { get; private set; }

        //public static bool ValidateToken(string token)
        //{

        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateAudience = true,
        //            ValidateIssuer = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidAudience = "http://localhost:4200",
        //            ValidIssuer = "https://localhost:7231",
        //            RequireSignedTokens = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salskmiddcmio32##8936@#"))
        //        }, out SecurityToken validatedToken);
        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var hh = jwtToken.Claims;
        //        var roleId = jwtToken.Claims.Where(m => m.Type == ClaimTypes.GroupSid).FirstOrDefault().Value;
        //        bool master = false;
        //        //if (roleId == GlobalVariable.MasterRoleId.ToString())
        //        //{
        //        //    master = true;
        //        //}
        //        return true;
        //        //return new TokenValidation() { IsTokenValid = true, IsMaster = master };
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        //return new TokenValidation() { IsTokenValid = false, Error = ex.Message };
        //    }
        //}
    }
}
