using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTestingProject
{
    public class DurationConverter : JsonConverter<TimeSpan>
    {
        private Regex m_regex = new Regex(@"\APT(?<hours>\d{2})H((?<minutes>\d{2})M)?\z");

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string input = (string)reader.Value;

            Match match = m_regex.Match(input);

            if (!match.Success)
                throw new Exception("Invalid duration string in Json input.");

            GroupCollection groups = match.Groups;

            int hours = Int32.Parse(groups["hours"].Value);

            int minutes = groups["minutes"].Success ? Int32.Parse(groups["minutes"].Value) : 0;

            return new TimeSpan(hours, minutes, 0);
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            string output = "PT" + value.Hours.ToString("D2") + "H" + ((value.Minutes == 0) ? "" : value.Minutes.ToString("D2") + "M");

            writer.WriteValue(output);
        }
    }
}
