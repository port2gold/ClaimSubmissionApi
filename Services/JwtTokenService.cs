using ClaimSubmissionApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ClaimSubmissionApi.Services
{
    public static class JwtTokenService
    {
        public static string GetToken(ApplicationUser user, string key, IEnumerable<string> userRoles)
        {

            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(type: "Identifier", user.Id),
                new System.Security.Claims.Claim(type: "Email", user.Email ?? string.Empty),
                new System.Security.Claims.Claim(type: "FirstName", user.FirstName ?? string.Empty)
            };
            foreach (var role in userRoles)
            {
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role));
            }

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var creds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512Signature);

            var securityTokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(securityTokenDescription);
            return tokenHandler.WriteToken(token);

        }
    }
}
