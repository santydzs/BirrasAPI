using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMeetBusiness
    {
        Task<List<MeetDTO>> GetAll();
        Task AddMeetWithInvitations(MeetDTO dto, List<int> users);
        Task<List<string>> GetNotifications(int meetId);
    }
}
