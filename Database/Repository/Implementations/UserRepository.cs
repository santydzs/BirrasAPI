using Database.Entity;
using Database.Repository.Interfaces;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Implementations
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(BirrasContext context) : base(context) { }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(x => x.Rol).ToListAsync();
        }

        public async Task Add(UserDTO dto)
        {
            User newUser = new User()
            {
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password,
                RolId = dto.RolId
            };
            await _context.Users.AddAsync(newUser);
        }
    }
}
