using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uFood.Infrastructure.Configuration
{
    public class LichBildConfiguration
    {
        [JsonProperty(PropertyName = "ospenDataEndpoint")]

        public string OpenDataEndpoint { get; set; }


    }
}
