using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class FlightOffer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lastTicketingDate")]
        public DateTime LastTicketingDate { get; set; }

        [JsonProperty("numberOfBookableSeats")]
        public int NumberOfBookableSeats { get; set; }

        [JsonProperty("itineraries")]
        public List<Itinerary> Itineraries { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }
}
