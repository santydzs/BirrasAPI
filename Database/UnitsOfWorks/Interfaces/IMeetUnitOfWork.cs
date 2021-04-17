using Database.Repository.Interfaces;
using System.Threading.Tasks;

namespace Database.UnitsOfWorks.Interfaces
{
    public interface IMeetUnitOfWork
    {
        IMeetRepository Meets { get; }
        Task<int> Complete();
    }
}
