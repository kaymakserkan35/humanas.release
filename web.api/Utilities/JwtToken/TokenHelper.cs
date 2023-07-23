using entity.entities;
using Faker;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web.api.Utilities.JwtToken;

namespace web.api.Utilities.JwtTokenHelper
{
    public class TokenHelper : ITokenHelper
    {



        public string CreateJwtToken(UserExt user, double jwtExpiresInMinute)
        {
           
            /*sercurity key yeterince uzun olmadıgında out of range hatası veriyor*/
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtHeader jwtheader = new JwtHeader(signingCredentials);
            JwtPayload jwtpayload = new JwtPayload(
               issuer: JwtConfig.Issuer, // tokeni kim dağıtıyor 
            audience: JwtConfig.Audience,// tokeni kimler kullanabiliyor
               claims: SetClaims(user),
               expires: DateTime.Now.AddMinutes(jwtExpiresInMinute),
               notBefore: DateTime.Now
               );
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(jwtheader, jwtpayload);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var serializedToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return serializedToken;
        }

        public string CreateRefreshToken()
        {

            var refreshToken = Guid.NewGuid().ToString();
            return refreshToken;
        }

        public IEnumerable<Claim> SetClaims(UserExt user)
        {
            // tokenin benzersiz olması için yapılıyor.... 2 kişi aynı tokeni alamasın diye.
            var claims = new List<Claim>();
            claims.Add(new Claim(type: "UserId", user.Id.ToString()));
            claims.Add(new Claim(type: "Email", value: user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            return claims;
        }
    }
}
