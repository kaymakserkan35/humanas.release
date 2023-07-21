using entity.entities;
using humanas.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using web.api.Utilities.Constants;
using web.api.Utilities.Results;

namespace ui.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient apiClient;
        private readonly ILogger<HomeController> logger;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;
        private readonly string localhostUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {

            this.env = env;
            this.logger = logger;
            this.localhostUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
            this.apiClient = httpClientFactory.CreateClient();
            apiClient.BaseAddress = new Uri(localhostUrl);
        }


        public async Task<IActionResult> Index()
        {
            /*
             * var response = await apiClient.GetAsync(Apis.distritcs); // API'den veriyi çekin
            response.EnsureSuccessStatusCode(); // Eğer başarısız olursa hata atsın

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var result = await JsonSerializer.DeserializeAsync<Response<District>>(responseStream); // API'den dönen JSON veriyi deserializasyon yapın
                return View(result.Data); // View'e veriyi gönderin
            }
             */

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
