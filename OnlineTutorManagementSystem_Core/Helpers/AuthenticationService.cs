using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineTutorManagementSystem_Core.Helpers
{
    public static class AuthenticationService
    {
        public static string IsAuthenticated(string token, string Id = "-1")
        {
            try
            {
                var tokendec = new JwtSecurityToken(token);
                DateTime dateTime = DateTime.UtcNow;
                DateTime expires = tokendec.ValidTo;
                var claims = tokendec.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
                string? UserId = tokendec.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                string? UserType = tokendec.Claims.FirstOrDefault(x => x.Type == "UserType").Value;
                if (!Id.Equals("-1") && !UserId.Equals(Id))
                {
                    return "";
                }
                //UserType=Doctor
                if (expires <= dateTime)
                {
                    return "";

                }
                return UserType;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return "Teacher";
            }
        }
        public static string GenerateJWTToken(string UserId, string UserType)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, UserId),
                new Claim(ClaimTypes.Name, UserType),
            };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
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
