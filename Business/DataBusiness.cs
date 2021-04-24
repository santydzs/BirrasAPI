using Business.Interfaces;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Business
{
    public class DataBusiness : IDataBusiness
    {
        private IWeatherLogic _service { get; set; }

        public DataBusiness(IWeatherLogic service)
        {
            _service = service;
        }

        public async Task<decimal> GetTemperature(string city)
        {
            return await _service.GetTemperature(city);
        }

        public int GetBeersByTemp(decimal temperature, int persons)
        {
            if(temperature < 20)
            {
                return (int)roundUp((float)((persons * 0.75) / 6));
            }
            else
            {
                if (temperature > 24)
                {
                    return (int)roundUp(((persons * 2) / 6));
                }
                else
                {
                    return (int)roundUp((float)persons / 6);
                }
            }
        }

        private double roundUp(float number)
        {
            return System.Math.Round(number, 0, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
