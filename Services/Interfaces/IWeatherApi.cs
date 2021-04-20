using Refit;
using Services.QueryParams;
using Services.Response;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWeatherApi
    {
        [Get("/weather")]
        Task<WeatherResponse> GetTemperature(WeatherQueryParams queryParams, [Header("x-rapidapi-key")] string key, [Header("x-rapidapi-host")] string host);
    }
}
