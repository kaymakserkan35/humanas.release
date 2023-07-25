using entity.entities;

namespace ui.Models.EntityModels
{
    public class DistrictModel
    {

        public DistrictModel(District entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Country = entity.Country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
