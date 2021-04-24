using Database.Entity;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IMeetRepository : IBaseRepository
    {
        Task<int> Add(MeetDTO dto);

        Task<List<Notification>> GetNotifications(int meetId);
        Task<Meet> GetFromtitle(string title);
    }
}
