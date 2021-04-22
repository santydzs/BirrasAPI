using Domain.DTOs;
using System.Collections.Generic;

namespace BirrasAPI.Request
{
    public class AddMeetRequest : MeetDTO
    {
        public List<int> usersIds { get; set; }
    }
}
