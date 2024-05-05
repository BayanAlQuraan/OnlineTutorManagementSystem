using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineTutorManagementSystem_Core.Helpers
{
    public static class AuthenticationService
    {
        public static string GenerateJWTToken(string UserId, string UserType)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, UserId),
                new Claim(ClaimTypes.Name, UserType),
            };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes("OnlineTutorManagementSystemBayanQuraan1999")
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
