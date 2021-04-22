using BirrasAPI.Request;
using Business.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task Add([FromBody] AddMeetRequest request)
        {
            await _business.AddMeetWithInvitations(request, request.usersIds);
        }
    }
}
