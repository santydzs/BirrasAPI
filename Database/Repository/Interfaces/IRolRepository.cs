using Database.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAll();

        Task<int> GetId(string title);
    }
}
