using Database.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Database.UnitsOfWorks.Implementations
{
    public class BaseUnitOfWorks
    {
        protected readonly BirrasContext _context;

        public BaseUnitOfWorks(BirrasContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
