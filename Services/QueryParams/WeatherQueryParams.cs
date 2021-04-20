using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.QueryParams
{
    public class WeatherQueryParams
    {
        [AliasAs("q")]
        public string City { get; set; }

        [AliasAs("units")]
        public string Units { get; set; }
    }
}
