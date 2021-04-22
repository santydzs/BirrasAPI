using Database.Entity;
using Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class InvitationsRepository : BaseRepository, IinvitationRepository
    {
        public InvitationsRepository(BirrasContext context) : base(context) { }

        public async Task<int> Add(int meetId, int userId)
        {
            Invitation newInv = new Invitation()
            {
                Attended = false,
                UserId = userId
            };
            await _context.Invitations.AddAsync(newInv);

            await _context.SaveChangesAsync();
                
            MeetUserRelation relation = new MeetUserRelation()
            {
                InvitationId = newInv.Id,
                MeetId = meetId
            };

            await _context.SaveChangesAsync();

            return newInv.Id;
        }

        public async Task Attend(int invitationId)
        {
            var invitation = await _context.Invitations.FirstOrDefaultAsync(x => x.Id == invitationId);

            invitation.Attended = true;
        }
    }
}
