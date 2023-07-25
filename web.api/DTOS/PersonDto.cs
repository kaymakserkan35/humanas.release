using entity.entities;

namespace web.api.DTOS
{
    public class PersonDto
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public PersonDto()
        {

        }

        public PersonDto(UserExt user )
        {
            this.id = user.Id;
            this.Title = user.Title;
            this.Name = user.UserName;
            this.Surname = user.SurName;
        }
    }
}
