using Database.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IinvitationRepository : IBaseRepository
    {
        Task<int> Add(int meetId, int userId);
        Task Attend(int invitationId);
        Task<List<Invitation>> GetAllFromDate(DateTime date, int userid);
    }
}
