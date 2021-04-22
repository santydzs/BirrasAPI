using BirrasAPI.Request;
using Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeetController : ControllerBase
    {
        private IMeetBusiness _business { get; set; }

        public MeetController(IMeetBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _business.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNotifications(int id)
        {
            return Ok(await _business.GetNotifications(id));
        }

        [HttpPost]
        public async Task Add([FromBody] AddMeetRequest request)
        {
            await _business.AddMeetWithInvitations(request, request.usersIds);
        }
    }
}
