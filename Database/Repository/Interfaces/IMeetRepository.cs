using Database.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IMeetRepository : IBaseRepository
    {
        Task<List<Meet>> GetAllFromDate(DateTime date);
    }
}
