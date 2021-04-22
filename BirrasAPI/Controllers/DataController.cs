using Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DataController : ControllerBase
    {
        private IDataBusiness _business { get; set; }

        public DataController(IDataBusiness business)
        {
            _business = business;
        }

        [HttpGet()]
        [Route("Temp")]
        public async Task<IActionResult> Get([FromQuery] string city)
        {
            return Ok(new {Temperature = await _business.GetTemperature(city)});
        }

        [HttpGet]
        [Route("beers")]
        public async Task<IActionResult> GetBeers([FromQuery] string city, [FromQuery] int persons)
        {
            return Ok(new {containersOfBeers = await _business.GetHowManyBeers(city, persons)});
        }
    }
}
