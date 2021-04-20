using Refit;
using Services.Interfaces;
using Services.QueryParams;
using System.Threading.Tasks;

namespace Services.Logic
{
    public class WeatherLogic : IWeatherLogic
    {
        private string _key { get; set; }
        private string _host { get; set; }
        public WeatherLogic(string key, string host)
        {
            _key = key;
            _host = host;
        }
        public async Task<decimal> GetTemperature(string city)
        {
            var api = RestService.For<IWeatherApi>("https://community-open-weather-map.p.rapidapi.com");
            var r = new WeatherQueryParams()
            {
                Units = "metric",
                City = city
            };

            var response = await api.GetTemperature(r, _key, _host);
            return response.main.temp;
        }
    }
}
