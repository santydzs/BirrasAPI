using Database.Entity;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IMeetRepository : IBaseRepository
    {
        Task<List<Meet>> GetAllFromDate(DateTime date);

        Task<int> Add(MeetDTO dto);
    }
}
