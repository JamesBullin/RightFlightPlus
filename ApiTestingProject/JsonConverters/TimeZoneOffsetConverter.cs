using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class TimeZoneOffsetConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;

            if (value[0] == '+')
                value = value.Remove(0, 1);

            return TimeSpan.Parse(value);
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            string result = (value >= TimeSpan.Zero ? "+" : "-") + value.ToString("hh\\:mm");

            writer.WriteValue(result);
        }
    }
}
