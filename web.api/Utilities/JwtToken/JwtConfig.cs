using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace web.api.Utilities.JwtToken
{
    public class JwtConfig
    {

        private static Object key = new Object();

        static readonly JwtConfig instance;
        public static string shema { get; set; } = JwtBearerDefaults.AuthenticationScheme;
        public static string Issuer { get; set; } = "http://localhost:7179";
        public static string Audience { get; set; } = "http://localhost:7178";
        public static string SecurityKey { get; set; } = "qwerty35!-qwerty35!-qwerty35!-qwerty35!-qwerty35!";



        public static JwtConfig getInstance()
        {
            lock (key)
            {
                if (instance != null) return instance;
                return new JwtConfig();
            }

        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,// Bu sizin token üreten servis adınızdır.
                ValidAudience = Audience, // Bu sizin tokeni kullanacak olan hedef adınızdır.
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
            };
        }
    }
}
