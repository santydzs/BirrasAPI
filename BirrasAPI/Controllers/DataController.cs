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

        [HttpGet]
        [Route("beers")]
        public async Task<IActionResult> GetBeers([FromQuery] decimal temp, [FromQuery] int persons)
        {
            return Ok(new {containersOfBeers = _business.GetBeersByTemp(temp, persons)});
        }
    }
}
