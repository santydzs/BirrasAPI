using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Services.Response
{
    public class WeatherResponse
    {
        [JsonPropertyName("main")]
        public main main { get; set; }
    }
}
