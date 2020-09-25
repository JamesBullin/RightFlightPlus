using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class OperatorConverter : JsonConverter<string>
    {
        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject operating = (JObject)JToken.ReadFrom(reader);

            return operating["carrierCode"].ToString();
        }

        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            JObject operating = new JObject();

            operating["carrierCode"] = value;

            operating.WriteTo(writer);
        }
    }
}
