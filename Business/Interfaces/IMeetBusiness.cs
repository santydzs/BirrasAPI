using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMeetBusiness
    {
        Task<List<invitationDTO>> GetAll(DateTime day, int userId);
        Task AddMeetWithInvitations(MeetDTO dto, List<int> users);
        Task<List<string>> GetNotifications(int meetId);
        Task<int> JoinMeet(string title, int userId);
        Task Assist(int invitationId);
    }
}
