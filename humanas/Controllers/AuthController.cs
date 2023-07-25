using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using ui.Models.ViewModels;
using web.api.Controllers;
using web.api.DTOS;
using web.api.Utilities.Constants;


namespace ui.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient apiClient;

        public AuthController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration;
            this.apiClient = httpClientFactory.CreateClient();
            apiClient.BaseAddress = new Uri(Apis.baseUrl); // Replace with your API base URL
        }




        [HttpGet]
        public IActionResult Auth()
        {
            return View("Auth", new AuthModel());
        }


        [HttpPost]
        public async Task<IActionResult> LogInOrSıgnIn(AuthModel model)
        {

            string requestUrl = Apis.authorizeUser;

            var dto = new SignInLogInDto()
            {
                Email = model.Email,
                Password = model.Password
            };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await apiClient.PostAsync(requestUrl, body);

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Response<TokenDto>>(responseContent);


                if (response.IsSuccess) return RedirectToAction("Index", "Home");
                else throw new Exception(response.Message);


            }

            else throw new Exception(httpResponse.ToString());
        }



    }
}
