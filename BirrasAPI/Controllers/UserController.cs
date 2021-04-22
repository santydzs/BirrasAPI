using Business.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpPost]
        public async Task Add([FromBody] UserCreateDTO request)
        {
            await _business.Add(request);
        }
    }
}
