using System;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(AircraftConverter))]
        public string AircraftCode { get; set; }

        [JsonProperty("operating")]
        [JsonConverter(typeof(OperatorConverter))]
        public string OperatorCode { get; set; }

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
