using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web.api.DTOS;
using web.api.Utilities.JwtTokenHelper;

namespace web.api.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenHelper tokenHelper;
        private readonly IConfiguration configuration;
        private readonly UserManager<UserExt> userManager;
        private readonly SignInManager<UserExt> signInManager;
        public AuthController(IConfiguration configuration, ITokenHelper tokenHelper, UserManager<UserExt> userManager, SignInManager<UserExt> signInManager)
        {
            this.configuration = configuration;
            this.tokenHelper = tokenHelper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        internal async Task<UserExt> AuthenticateUser(string email, string password)
        {
            // Önce mevcut kullanıcıyı doğrula
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                // Kullanıcı mevcut, şifreyi doğrula
                var res = await signInManager.PasswordSignInAsync(existingUser, password, isPersistent: false, lockoutOnFailure: false);
                if (res.Succeeded) return existingUser;
                else throw new Exception("");

            }

            // Kullanıcı mevcut değil, yeni kullanıcı oluştur
            var newUser = new UserExt
            {
                Title = email.Split('@')[0],
                SurName = email.Split('@')[0],
                UserName = email,
                Email = email,
                // Diğer kullanıcı özelliklerini de burada belirtebilirsiniz
            };

            // Yeni kullanıcıyı kaydet
            var result = await userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                // Yeni kullanıcı başarıyla oluşturuldu, giriş yap
                await signInManager.SignInAsync(newUser, isPersistent: false);
                return newUser;
            }
            else throw new Exception("");


        }



        [HttpPost]
        [Route("[action]")]
        public async Task<Response<TokenDto>> AuthorizeUser(SignInLogInDto dto)
        {



            var user = await AuthenticateUser(dto.Email, dto.Password);

            var serializedjwt = tokenHelper.CreateJwtToken(user, 1);
            var refreshToken = tokenHelper.CreateRefreshToken();

            user.JwtToken = serializedjwt;
            user.RefrestToken = refreshToken;
            user.RefresTokenExpTime = DateTime.Now.AddMinutes(0.3);


            await userManager.UpdateAsync(user);
            var obj = new TokenDto()
            {
                jwtToken = serializedjwt,
                refreshToken = refreshToken
            };
            return new Response<TokenDto> { Data = obj };

        }


        [HttpPost]
        [Route("[action]")]
        public async Task<string> AuthorizeByRefreshToken(string refreshToken)
        {
            var user = userManager.Users.Where(x => x.RefrestToken == refreshToken).FirstOrDefault();
            if (user.RefresTokenExpTime > DateTime.Now)
            {
                var serializedjwt = tokenHelper.CreateJwtToken(user, 1);
                var newRefreshToken = tokenHelper.CreateRefreshToken();

                user.JwtToken = serializedjwt;
                user.RefrestToken = newRefreshToken;
                user.RefresTokenExpTime = DateTime.Now.AddMinutes(0.3);

                await userManager.UpdateAsync(user);
                return newRefreshToken;
            }


            throw new Exception("");
        }

        // apide gözükmesin. private olsun.
        private async Task<UserExt> FindCurrentUser()
        {
            // Kullanıcının talep eden kimliğini al
            var requestingUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // UserManager ile kullanıcıyı bul
            var user = await userManager.FindByIdAsync(requestingUserId);
            return user;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public string RequireRefreshToken()
        {
            var user = FindCurrentUser().Result;
            user.RefrestToken = tokenHelper.CreateRefreshToken();
            user.RefresTokenExpTime = DateTime.Now.AddMinutes(0.3);
            userManager.UpdateAsync(user);

            return user.RefrestToken;
        }

    }
}
