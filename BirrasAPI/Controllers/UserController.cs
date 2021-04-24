using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _business { get; set; }

        public UserController(IUserBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _business.GetAll());
        }
    }
}
