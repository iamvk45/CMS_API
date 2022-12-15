
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS_API.Helper
{
    public static class GetSettings
    {
        #region JWT Token Generate
        static string secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["secret"];
        static string issuer = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["issuer"];
        static string audience = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["audience"];
        static string accessExpiration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["accessExpiration"];
        static string baseURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["baseUrl"];
        public static string JWT_GetToken(string username)
        {
            var claims = new[]
{
                 new Claim(ClaimTypes.Name,username)
             };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(double.Parse(accessExpiration)), signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }

        #endregion
    }
}
