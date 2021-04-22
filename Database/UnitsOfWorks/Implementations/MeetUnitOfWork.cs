using Database.Entity;
using Database.Repository.Implementations;
using Database.Repository.Interfaces;
using Database.UnitsOfWorks.Interfaces;

namespace Database.UnitsOfWorks.Implementations
{
    public class MeetUnitOfWork : BaseUnitOfWorks, IMeetUnitOfWork
    {
        public MeetUnitOfWork(BirrasContext context) : base(context)
        {
            Meets = new MeetRepository(_context);
            Invitations = new InvitationsRepository(_context);
        }
        public IMeetRepository Meets { get; private set; }
        public IinvitationRepository Invitations { get; private set; }
    }
}
