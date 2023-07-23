using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using web.api.Controllers;
using web.api.DTOS;
using web.api.Utilities.Constants;


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
            this.configuration= configuration;
            this.apiClient = httpClientFactory.CreateClient();
            apiClient.BaseAddress = new Uri(Apis.baseUrl);
        }


        public async Task<IActionResult> Index()
        {

            var httpResponse = await apiClient.GetAsync(Apis.distritcs); // API'den veriyi çekin
            httpResponse.EnsureSuccessStatusCode(); // Eğer başarısız olursa hata atsın

            using (var responseStream = await httpResponse.Content.ReadAsStreamAsync())
            {
                var response = await JsonSerializer.DeserializeAsync<Response<List<District>>>(responseStream); // API'den dönen JSON veriyi deserializasyon yapın
                var data = response.Data;
                return View(data); // View'e veriyi gönderin
            }

        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
