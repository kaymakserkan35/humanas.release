using data.access;
using Microsoft.AspNetCore.Mvc;
using ui.Models;

namespace ui.Components
{
    [ViewComponent]
    public class Search_Filter : ViewComponent
    {
        private IRepository repository;
        public Search_Filter(IRepository repository)
        {
            this.repository = repository;
        }


        public IViewComponentResult Invoke()
        {
            List<DistrictModel> districtModels = new List<DistrictModel>();
            List<MotivationModel> motivationModels = new List<MotivationModel>();
            List<WorkingPreferenceModel> workingPreferenceModels = new List<WorkingPreferenceModel>();

            SearchFilterModel searchFilterModel = new SearchFilterModel(workingPreferenceModels, districtModels, motivationModels);

            var districts = repository.districts.ToList();
            var motivations = repository.motivations.ToList();
            var preferences = repository.workingPreferences.ToList();

            foreach (var x in districts) districtModels.Add(new DistrictModel(x));
            foreach (var x in motivations) motivationModels.Add(new MotivationModel(x));
            foreach (var x in preferences) workingPreferenceModels.Add(new WorkingPreferenceModel(x));




            return View(searchFilterModel);
        }
    }
}
