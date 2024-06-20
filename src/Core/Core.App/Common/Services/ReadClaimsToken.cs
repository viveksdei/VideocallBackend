using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.App.Common.Services
{
    public class ReadClaimsToken : IReadClaimsToken
    {
        public IEnumerable<Claim> GetUserClaimsDetails(string Token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.ReadJwtToken(Token);
            var claims = jwtToken.Claims;
            var actorName = jwtToken.Actor;
            return claims;
        }
    }
}
