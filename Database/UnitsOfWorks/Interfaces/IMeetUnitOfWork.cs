using Database.Repository.Interfaces;

namespace Database.UnitsOfWorks.Interfaces
{
    public interface IMeetUnitOfWork : IBaseUnitOfWorks
    {
        IMeetRepository Meets { get; }
        IinvitationRepository Invitations { get; }
    }
}
