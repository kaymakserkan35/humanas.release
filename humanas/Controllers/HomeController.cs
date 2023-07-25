using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using ui.Models.EntityModels;
using ui.Models.ViewModels;
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



        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {

            this.env = env;
            this.logger = logger;
            this.configuration = configuration;
            this.apiClient = httpClientFactory.CreateClient();
            apiClient.BaseAddress = new Uri(Apis.baseUrl);
        }


        public IActionResult Index()
        {
            return View(); // View'e veriyi gönderin
        }

        public async Task<IActionResult> Search()
        {
            string directLink = "Service/ReadAllPersons";
            var httpResponse = await apiClient.GetAsync(directLink); // API'den veriyi çekin
            httpResponse.EnsureSuccessStatusCode(); // Eğer başarısız olursa hata atsın

            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response<List<PersonDto>>>(content);
            var data = response.Data;


            var model = new SearchModel();
            List<SearchPersonModel> models = new List<SearchPersonModel>();


            /*
            // cashleme yapılabilir ve ya client tarafında veri bölümlemesi yapılabilir. biz şimdilik burada bölelim.
            yada daha iyisi client tarafında yapmak. çünki zaten filtrelenmiş veriler gönderiliyor.
            model.searchResultModel = new SearchResultModel();
            var pageNum = Math.Ceiling(Convert.ToDouble(data.Count / model.searchResultModel.PageSize));
            model.searchResultModel.PageNumber = Convert.ToInt16(pageNum);
            var returning = data.Skip((model.searchResultModel.CurrentPage - 1) * model.searchResultModel.PageSize).Take(model.searchResultModel.PageSize).ToList();

            */
            model.searchResultModel = new SearchResultModel();
            data.ForEach(d => { models.Add(new SearchPersonModel(d)); });
            model.searchResultModel.searchPersonModels = models;
            return View(model);
        }




        [HttpPost]
        public async Task<IActionResult>? FilterResult(SearchFilterModel model)
        {
            /*
            var queryString = new Dictionary<string, string>   {
            { "selectedDistricts", string.Join(",", model.selectedDistricts) },
            { "selectedMotivations", string.Join(",",model.selectedMotivations) },
            { "workingPreferences", string.Join(",",     model.workingPreferences) } };

            var queryString2 = $"?selectedDistricts={string.Join(",", model.selectedDistricts)}&selectedMotivations={string.Join(",", model.selectedMotivations)}&workingPreferences={string.Join(",", model.workingPreferences)}";
            */
            var dto = new FilterPersonsDto(model.selectedMotivations, model.selectedWorkingPreferences, model.selectedDistricts);

            var httpResponse = await apiClient.PostAsJsonAsync(Apis.personsFiltered, dto);
            httpResponse.EnsureSuccessStatusCode(); // Eğer başarısız olursa hata atsın

            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response<List<PersonDto>>>(content);
            var data = response.Data;

            SearchModel m = new SearchModel();
            SearchResultModel returnng = new SearchResultModel();
            returnng.searchPersonModels = new List<SearchPersonModel>();
            m.searchResultModel = returnng;

            data.ForEach(d => { returnng.searchPersonModels.Add(new SearchPersonModel(d)); });

            return View("Search", m);
        }
    }


}
