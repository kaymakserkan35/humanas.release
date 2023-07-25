namespace web.api.DTOS
{
    public class FilterPersonsDto
    {
        public FilterPersonsDto()
        {

        }

        public FilterPersonsDto(List<int> motivationIds, List<int> workingPreferenceIds, List<int> districtIds)
        {
            this.motivationIds = motivationIds;
            this.workingPreferenceIds = workingPreferenceIds;
            this.districtIds = districtIds;
        }

        public List<int> motivationIds { get; set; }
        public List<int> workingPreferenceIds { get; set; }
        public List<int> districtIds { get; set; }
    }
}
