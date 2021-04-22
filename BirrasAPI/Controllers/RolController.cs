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
    public class RolController : ControllerBase
    {
        private IUserBusiness _business { get; set; }

        public RolController(IUserBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _business.GetAllRoles());
        }
    }
}
