using Database.Entity;
using Database.Repository.Interfaces;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class MeetRepository : BaseRepository, IMeetRepository
    {
        public MeetRepository(BirrasContext context): base(context) { }
        public async Task<Meet> GetFromtitle(string title)
        {
            return await _context.Meets.FirstOrDefaultAsync(x => x.Title == title);
        }
        public async Task<int> Add(MeetDTO dto)
        {
            Meet newMeet = new Meet()
            {
                Address = dto.Address,
                City = dto.City,
                Date = dto.Date,
                Title = dto.Title,
            };

            await _context.AddAsync(newMeet);
            await _context.SaveChangesAsync();

            return newMeet.Id;
        }

        public async Task<List<Notification>> GetNotifications(int meetId)
        {
            return await _context.Notifications.Where(x => x.MeetId == meetId).ToListAsync();
        }
    }
}
