using System;
using Newtonsoft.Json;

namespace ApiTestingProject
{
    public class GeoCode
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
