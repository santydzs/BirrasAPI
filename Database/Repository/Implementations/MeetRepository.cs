using Database.Entity;
using Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class MeetRepository : BaseRepository, IMeetRepository
    {
        public MeetRepository(BirrasContext context): base(context) { }
        public Task<List<Meet>> GetAllFromDate(DateTime date)
        {
            return _context.Meets.ToListAsync();
        }
    }
}
