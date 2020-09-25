using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class Aircraft
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
