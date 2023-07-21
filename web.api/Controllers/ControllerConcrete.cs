using data.access;
using entity.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web.api.Utilities.Results;

namespace web.api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ControllerConcrete : ControllerBase
    {
        private IRepository repository;
        public ControllerConcrete(IRepository repository)
        {
            this.repository = repository;
        }


        /// <summary>
        ///user first must be  autohnticad 
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public Response<UserExt>? Get() { return null; }

        [HttpGet]
        [Route("[action]")]
        public Response<District> ReadAllDistrict()
        {
            var result = new Response<District>();
            result.Data = repository.districts;
            return result;
        }
    }
}