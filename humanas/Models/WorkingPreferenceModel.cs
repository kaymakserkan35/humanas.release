using entity.entities;

namespace ui.Models
{
    public class WorkingPreferenceModel
    {
        public WorkingPreferenceModel(WorkingPreference entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
