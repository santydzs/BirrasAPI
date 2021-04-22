using Database.Entity;
using Database.Repository.Implementations;
using Database.Repository.Interfaces;
using Database.UnitsOfWorks.Interfaces;

namespace Database.UnitsOfWorks.Implementations
{
    public class UserUnitOfWork : BaseUnitOfWorks, IUserUnitOfWork
    {
        public UserUnitOfWork(BirrasContext context) : base(context)
        {
            Users = new UserRepository(_context);
            Rols = new RolRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public IRolRepository Rols { get; private set; }
    }
}
