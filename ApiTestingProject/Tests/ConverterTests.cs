using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ApiTestingProject
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void AircraftSerializedCorrectly()
        {
            AircraftDummyObject dummyObject = new AircraftDummyObject
            {
                AircraftCode = "737"
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["aircraft"]["code"].ToString(), Is.EqualTo("737"));
        }

        [Test]
        public void OperatorSerializedCorrectly()
        {
            OperatorDummyObject dummyObject = new OperatorDummyObject
            {
                OperatorCode = "BA"
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["operating"]["carrierCode"].ToString(), Is.EqualTo("BA"));
        }

        [Test]
        public void AircraftDeserializedCorrectly()
        {
            JObject j = new JObject
            {
                ["aircraft"] = new JObject
                {
                    ["code"] = "737"
                }
            };

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<AircraftDummyObject>(dummyObjectRaw), Throws.Nothing);

            AircraftDummyObject dummyObject = JsonConvert.DeserializeObject<AircraftDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.AircraftCode, Is.EqualTo("737"));
        }

        [Test]
        public void OperatorDeserializedCorrectly()
        {
            JObject j = new JObject
            {
                ["operating"] = new JObject
                {
                    ["carrierCode"] = "BA"
                }
            };


            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<OperatorDummyObject>(dummyObjectRaw), Throws.Nothing);

            OperatorDummyObject dummyObject = JsonConvert.DeserializeObject<OperatorDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.OperatorCode, Is.EqualTo("BA"));
        }

        [TestCase(5, 0, "+05:00")]
        [TestCase(7, 30, "+07:30")]
        [TestCase(-4, 0, "-04:00")]
        [TestCase(-6, -30, "-06:30")]
        [TestCase(0, 0, "+00:00")]
        public void TimeZoneOffsetSerializedCorrectly(int hours, int minutes, string expected)
        {
            TimeZoneOffsetDummyObject dummyObject = new TimeZoneOffsetDummyObject
            {
                TimeZoneOffset = new TimeSpan(hours, minutes, 0)
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["timeZoneOffset"].ToString(), Is.EqualTo(expected));
        }

        [TestCase("+03:00", 3, 0)]
        [TestCase("+02:30", 2, 30)]
        [TestCase("-07:00", -7, 0)]
        [TestCase("-06:30", -6, -30)]
        [TestCase("+00:00", 0, 0)]
        public void TimeZoneOffsetDeserializedCorrectly(string input, int expectedHours, int expectedMinutes)
        {
            JObject j = new JObject
            {
                ["timeZoneOffset"] = input
            };

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw), Throws.Nothing);

            TimeZoneOffsetDummyObject dummyObject = JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.TimeZoneOffset, Is.EqualTo(new TimeSpan(expectedHours, expectedMinutes, 0)));
        }

        [TestCase(5, 30, "PT05H30M")]
        [TestCase(4, 5, "PT04H05M")]
        [TestCase(14, 20, "PT14H20M")]
        [TestCase(7, 0, "PT07H")]
        public void DurationSerializedCorrectly(int hours, int minutes, string expected)
        {
            DurationDummyObject dummyObject = new DurationDummyObject
            {
                Duration = new TimeSpan(hours, minutes, 0)
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["duration"].ToString(), Is.EqualTo(expected));
        }

        [TestCase("PT04H15M", 4, 15)]
        [TestCase("PT08H05M", 8, 5)]
        [TestCase("PT12H10M", 12, 10)]
        [TestCase("PT03H", 3, 0)]
        public void DurationDeserializedCorrectly(string input, int expectedHours, int expectedMinutes)
        {
            JObject j = new JObject
            {
                ["duration"] = input
            };

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<DurationDummyObject>(dummyObjectRaw), Throws.Nothing);

            DurationDummyObject dummyObject = JsonConvert.DeserializeObject<DurationDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.Duration, Is.EqualTo(new TimeSpan(expectedHours, expectedMinutes, 0)));
        }

        private class AircraftDummyObject
        {
            [JsonProperty("aircraft")]
            [JsonConverter(typeof(AircraftConverter))]
            public string AircraftCode { get; set; }
        }

        private class OperatorDummyObject
        {
            [JsonProperty("operating")]
            [JsonConverter(typeof(OperatorConverter))]
            public string OperatorCode { get; set; }
        }

        private class TimeZoneOffsetDummyObject
        {
            [JsonProperty("timeZoneOffset")]
            [JsonConverter(typeof(TimeZoneOffsetConverter))]
            public TimeSpan TimeZoneOffset { get; set; }
        }

        private class DurationDummyObject
        {
            [JsonProperty("duration")]
            [JsonConverter(typeof(DurationConverter))]
            public TimeSpan Duration { get; set; }
        }
    }
}
