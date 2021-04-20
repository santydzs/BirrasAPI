using Database.Entity;
using Database.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class InvitationsRepository : BaseRepository, IinvitationRepository
    {
        public InvitationsRepository(BirrasContext context) : base(context) { }

        public async Task Add(int meetId, List<int> userIds)
        {
            foreach(int userId in userIds)
            {
                using (var db = await _context.Database.BeginTransactionAsync())
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

                    db.Commit();
                }
                
            }
        }
    }
}
