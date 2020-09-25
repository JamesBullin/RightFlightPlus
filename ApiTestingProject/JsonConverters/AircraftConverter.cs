using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTestingProject
{
    public class AircraftConverter : JsonConverter<string>
    {
        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject aircraft = (JObject)JToken.ReadFrom(reader);

            return aircraft["code"].ToString();
        }

        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
        {
            JObject aircraft = new JObject();

            aircraft["code"] = value;

            aircraft.WriteTo(writer);
        }
    }
}
