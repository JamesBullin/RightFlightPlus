using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiTestingProject
{
    public class Itinerary
    {
        [JsonProperty("duration")]
        [JsonConverter(typeof(DurationConverter))]
        public TimeSpan Duration { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }
    }
}
