using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiTestingProject
{
    public class Operator
    {
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }
    }
}
