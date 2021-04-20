using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IinvitationRepository : IBaseRepository
    {
        Task Add(int meetId, List<int> userIds);
    }
}
