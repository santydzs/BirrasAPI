using Database.Entity;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        Task<List<User>> GetAll();

        Task Add(UserDTO dto);
    }
}
