using Database.Entity;
using Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class RolRepository : BaseRepository, IRolRepository
    {
        public RolRepository(BirrasContext context) : base(context) { }

        public async Task<List<Rol>> GetAll()
        {
            return await _context.Rols.ToListAsync();
        }

        public async Task<int> GetId(string title)
        {
            var rol = await _context.Rols.FirstOrDefaultAsync(x => x.Title == title);
            return rol.Id;
        }
    }
}
