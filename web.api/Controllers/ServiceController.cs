using data.access;
using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using web.api.DTOS;


namespace web.api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private IRepository repository;
        public ServiceController(IRepository repository)
        {
            this.repository = repository;
        }

        [Route("[action]")]
        [HttpGet]
        public Response<List<Motivation>>? ReadAllMotivations()
        {
            return new Response<List<Motivation>>() { Data = repository.motivations };


        }

        [HttpGet]
        [Route("[action]")]
        public Response<List<District>> ReadAllDistrict()
        {
            var result = new Response<List<District>>();

            result.Data = repository.districts;
            return result;
        }



        [HttpGet]
        [Route("[action]")]
        public Response<List<WorkingPreference>> ReadAllPreferences()
        {
            var result = new Response<List<WorkingPreference>>();
            result.Data = repository.workingPreferences;
            return result;
        }



        [HttpGet]
        [Route("[action]")]
        public Response<List<PersonDto>> ReadAllPersons()
        {

            var persons = new List<PersonDto>();
            foreach (var person in repository.persons) persons.Add(new PersonDto(person));
            return new Response<List<PersonDto>>(persons);
        }


        [HttpGet]
        [Route("[action]")] // birincisi fazla uzun url ler hata verir! ve bu get methodu client dan veri almak için güzenli değildir. link bir 3. part client tarafından kolayca değiştirilebilinir!
        public Response<List<PersonDto>> ReadPersonsByQuery([FromQuery] List<int> motivationIds, [FromQuery] List<int> workingPreferenceIds, [FromQuery] List<int> selectedUserDistricts)
        {

            var res = repository.persons
                  .Where(x => x.UserMotivations.Any(m => motivationIds.Contains(m.Id)))
                   .Where(x => x.UserWorkingPreferences.Any(m => workingPreferenceIds.Contains(m.Id)))
              .Where(x => x.UserDistricts.Any(m => selectedUserDistricts.Contains(m.Id)));



            var persons = new List<PersonDto>();
            foreach (var person in res) persons.Add(new PersonDto(person));
            return new Response<List<PersonDto>>(persons);
        }
        [HttpPost]
        [Route("[action]")] //en güvenli ve temiz yol
        public Response<List<PersonDto>> ReadPersonsByQuery([FromBody] FilterPersonsDto dto)
        {

            var res = repository.persons
                  .Where(x => x.UserMotivations.Any(m => dto.motivationIds.Contains(m.Id)))
                   .Where(x => x.UserWorkingPreferences.Any(m => dto.workingPreferenceIds.Contains(m.Id)))
              .Where(x => x.UserDistricts.Any(m => dto.districtIds.Contains(m.Id)));



            var persons = new List<PersonDto>();
            foreach (var person in res) persons.Add(new PersonDto(person));
            return new Response<List<PersonDto>>(persons);
        }
    }
}