using entity.entities;
using ui.Models.EntityModels;

namespace ui.Models.ViewModels
{
    public class SearchFilterModel
    {
        public List<WorkingPreferenceModel> workingPreferences;
        public List<DistrictModel> districts;
        public List<MotivationModel> motivations;



        public List<int> selectedWorkingPreferences { get; set; }
        public List<int> selectedDistricts { get; set; }
        public List<int> selectedMotivations { get; set; }



        public SearchFilterModel()
        {

        }
        public SearchFilterModel(List<WorkingPreferenceModel> workingPreferences, List<DistrictModel> districts, List<MotivationModel> motivations)
        {
            this.workingPreferences = workingPreferences;
            this.districts = districts;
            this.motivations = motivations;
        }
    }
}
