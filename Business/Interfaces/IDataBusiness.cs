using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDataBusiness
    {
        Task<decimal> GetTemperature(string city);
        Task<int> GetHowManyBeers(string city, int persons);
    }
}
