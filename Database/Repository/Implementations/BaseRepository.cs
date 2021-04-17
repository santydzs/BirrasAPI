using Database.Entity;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class BaseRepository
    {
        protected BirrasContext _context { get; set; }

        public BaseRepository(BirrasContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync()
;        }
    }
}
