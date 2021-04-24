using BirrasAPI.Request;
using Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeetController : ControllerBase
    {
        private IMeetBusiness _business { get; set; }
        private readonly ILogger _logger;

        public MeetController(IMeetBusiness business, ILogger<MeetController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _business.GetAll(DateTime.Today, id));
            }
            catch(Exception e)
            {
                _logger.LogError(e, "error in meets");
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMeetRequest request)
        {
            await _business.AddMeetWithInvitations(request, request.usersIds);
            return Ok();
        }

        [HttpPut("Assist/{id:int}")]
        public async Task<IActionResult> Assist(int id)
        {
            await _business.Assist(id);
            return Ok("Updated");
        }

        [HttpPost("unirse")]
        public async Task<IActionResult> join([FromBody] joinMeetRequest request)
        {
            return Ok(await _business.JoinMeet(request.Title, request.UserId));
        }
    }
}
