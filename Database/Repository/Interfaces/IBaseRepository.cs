using System.Threading.Tasks;

namespace Database.Repository.Interfaces
{
    public interface IBaseRepository
    {
        Task SaveChanges();
    }
}
