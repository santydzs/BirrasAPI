using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> Add(UserCreateDTO dto);
        Task<UserWithPassword> GetwithPassword(string email);
        Task<List<RolDTO>> GetAllRoles();
    }
}
