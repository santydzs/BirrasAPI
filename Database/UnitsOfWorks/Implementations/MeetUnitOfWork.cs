using Database.Entity;
using Database.Repository.Implementations;
using Database.Repository.Interfaces;
using Database.UnitsOfWorks.Interfaces;
using System.Threading.Tasks;

namespace Database.UnitsOfWorks.Implementations
{
    public class MeetUnitOfWork : IMeetUnitOfWork
    {
        private readonly BirrasContext _context;
        public MeetUnitOfWork(BirrasContext context)
        {
            _context = context;
            Meets = new MeetRepository(_context);
        }
        public IMeetRepository Meets { get; private set; }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
