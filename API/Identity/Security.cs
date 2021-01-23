
using API.Models;
using Core.Entities.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Identity
{
    public class Security
    {
        public static TokenViewModel GenerateJwtToken(string email, ApplicationUser user, TokenOption options, string role
            )
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Role, role),
                 new Claim(ClaimTypes.Email, email)
            };

            DateTime TokenExpiry;

            TokenExpiry = DateTime.Now.AddMinutes(options.ExpireMinutes);

            var token = new JwtSecurityToken
             (
                 issuer: options.Issuer,
                 audience: options.Audience,
                 claims: claims,
                 expires: TokenExpiry,
                 notBefore: DateTime.UtcNow,
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key)),
                         SecurityAlgorithms.HmacSha256)
             );
            var response = new TokenViewModel
            {
                UserName = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = TokenExpiry,
                Role = role,
                NAME = user.UserName ,
                UserId = user.Id, 
                Phone = user.PhoneNumber,
            };
            return response;
        }
    }
}
