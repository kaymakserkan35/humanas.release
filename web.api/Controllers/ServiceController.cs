using data.access;
using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web.api.DTOS;


namespace web.api.Controllers
{

    [Authorize]
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
    }
}