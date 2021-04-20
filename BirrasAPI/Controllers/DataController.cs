using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IDataBusiness _business { get; set; }

        public DataController(IDataBusiness business)
        {
            _business = business;
        }

        [HttpGet()]
        [Route("Temp")]
        public async Task<ActionResult<object>> Get([FromQuery] string city)
        {
            return new {Temperature = await _business.GetTemperature(city) };
        }

        [HttpGet]
        [Route("beers")]
        public async Task<ActionResult<object>> GetBeers([FromQuery] string city, [FromQuery] int persons)
        {
            return new {containersOfBeers = await _business.GetHowManyBeers(city, persons)};
        }
    }
}
