using entity.entities;
using System.Security.Claims;

namespace web.api.Utilities.JwtTokenHelper
{
    public interface ITokenHelper
    {
        public string CreateJwtToken(UserExt user, double expiresInMinutes);
        public string CreateRefreshToken();
        public IEnumerable<Claim> SetClaims(UserExt user);
    }
}
