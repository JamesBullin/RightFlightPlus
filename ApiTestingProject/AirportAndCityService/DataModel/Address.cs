using System;
using Newtonsoft.Json;

namespace ApiTestingProject
{
    public class Address
    {
        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("regionCode")]
        public string RegionCode { get; set; }
    }
}
