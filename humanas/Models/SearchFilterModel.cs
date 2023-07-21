using entity.entities;

namespace ui.Models
{
    public class SearchFilterModel
    {
        public List<WorkingPreferenceModel> workingPreferences;
        public List<DistrictModel> districts;
        public List<MotivationModel> motivations;

        public SearchFilterModel(List<WorkingPreferenceModel> workingPreferences, List<DistrictModel> districts, List<MotivationModel> motivations)
        {
            this.workingPreferences = workingPreferences;
            this.districts = districts;
            this.motivations = motivations;
        }
    }
}
