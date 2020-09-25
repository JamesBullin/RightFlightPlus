﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingProject
{
    public enum LocationType { Airport = 2, City = 4 }

    public class Airport
    {
        [JsonProperty("subType")]
        public LocationType SubType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detailedName")]
        public string DetailedName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timeZoneOffset")]
        public string TimeZoneOffset { get; set; }

        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("geoCode")]
        public GeoCode GeoCode { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
