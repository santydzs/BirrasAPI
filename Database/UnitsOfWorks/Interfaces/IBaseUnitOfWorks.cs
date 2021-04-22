using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Database.UnitsOfWorks.Interfaces
{
    public interface IBaseUnitOfWorks
    {
        Task<int> Complete();
        Task<IDbContextTransaction> CreateTransaction();
    }
}
