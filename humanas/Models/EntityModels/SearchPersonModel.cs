using entity.entities;
using web.api.DTOS;

namespace ui.Models.EntityModels
{
    public class SearchPersonModel
    {
        public SearchPersonModel()
        {

        }

        public SearchPersonModel(PersonDto user)
        {
            this.id = user.id;
            this.Name = user.Name;
            this.Title = user.Title;
            this.Surname = user.Title;
        }


        public int id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
