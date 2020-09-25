using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class FlightEndpoint
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }

        [JsonProperty("at")]
        public DateTime Time { get; set; }
    }
}
