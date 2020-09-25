using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class Segment
    {
        [JsonProperty("departure")]
        public FlightEndpoint Departure { get; set; }

        [JsonProperty("arrival")]
        public FlightEndpoint Arrival { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("operating")]
        public Operator Operating { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("numberOfStops")]
        public int NumberOfStops { get; set; }

        [JsonProperty("blacklistedInEU")]
        public bool BlacklistedInEu { get; set; }
    }
}
