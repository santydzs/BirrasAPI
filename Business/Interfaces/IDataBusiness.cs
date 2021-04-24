using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDataBusiness
    {
        Task<decimal> GetTemperature(string city);
        int GetBeersByTemp(decimal temperature, int persons);
    }
}
