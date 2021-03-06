using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
