using Database.Repository.Interfaces;

namespace Database.UnitsOfWorks.Interfaces
{
    public interface IUserUnitOfWork : IBaseUnitOfWorks
    {
        IUserRepository Users { get; }
        IRolRepository Rols { get;}
    }
}
