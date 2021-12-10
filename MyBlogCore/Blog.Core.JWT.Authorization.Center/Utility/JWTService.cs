using Blog.Core.JWT.Authorization.Center.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.JWT.Authorization.Center.Utility
{
    public class JWTService : IJWTService
    {
        private readonly JWTTokenOptions _JWTTokenOptions;
        public JWTService(IOptionsMonitor<JWTTokenOptions> JWTTokenOptions)
        {
            _JWTTokenOptions = JWTTokenOptions.CurrentValue;

        }
        public JWTModel GetToken(UserRequestModel user)
        {
            try
            {
                //有效载荷System.IdentityModel.Tokens.Jwt;
                var authClaims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim("test","test"),
                 new Claim("phone","15210221410"),
                 new Claim("scope","All")
            };
                
                var authSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTTokenOptions.SecretKey));
                SigningCredentials credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
                //生产token
                JwtSecurityToken toekn = new JwtSecurityToken(
                issuer: _JWTTokenOptions.IisUer,
                audience: _JWTTokenOptions.Audience,
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(1),
                 signingCredentials: credentials
                );
                var result = new JwtSecurityTokenHandler().WriteToken(toekn);
                return new JWTModel { Success = true, Toekn = result };
            }
            catch (Exception ex)
            {
                return new JWTModel { Success = false, Toekn = string.Empty };
            }
        }
    }
}
