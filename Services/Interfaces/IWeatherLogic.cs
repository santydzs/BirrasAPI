using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWeatherLogic
    {
        Task<decimal> GetTemperature(string city);
    }
}
