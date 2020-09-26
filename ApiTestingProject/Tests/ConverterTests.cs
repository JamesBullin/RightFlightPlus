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
            JObject j = new JObject();
            j["aircraft"] = new JObject();

            j["aircraft"]["code"] = "737";

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<AircraftDummyObject>(dummyObjectRaw), Throws.Nothing);

            AircraftDummyObject dummyObject = JsonConvert.DeserializeObject<AircraftDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.AircraftCode, Is.EqualTo("737"));
        }

        [Test]
        public void OperatorDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["operating"] = new JObject();

            j["operating"]["carrierCode"] = "BA";

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<OperatorDummyObject>(dummyObjectRaw), Throws.Nothing);

            OperatorDummyObject dummyObject = JsonConvert.DeserializeObject<OperatorDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.OperatorCode, Is.EqualTo("BA"));
        }

        [Test]
        public void PositiveTimeZoneOffsetSerializedCorrectly()
        {
            TimeZoneOffsetDummyObject dummyObject = new TimeZoneOffsetDummyObject
            {
                TimeZoneOffset = new TimeSpan(5, 0, 0)
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["timeZoneOffset"].ToString(), Is.EqualTo("+05:00"));
        }

        [Test]
        public void NegativeTimeZoneOffsetSerializedCorrectly()
        {
            TimeZoneOffsetDummyObject dummyObject = new TimeZoneOffsetDummyObject
            {
                TimeZoneOffset = new TimeSpan(-4, 0, 0)
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["timeZoneOffset"].ToString(), Is.EqualTo("-04:00"));
        }

        [Test]
        public void ZeroTimeZoneOffsetSerializedCorrectly()
        {
            TimeZoneOffsetDummyObject dummyObject = new TimeZoneOffsetDummyObject
            {
                TimeZoneOffset = TimeSpan.Zero
            };

            Assert.That(() => JsonConvert.SerializeObject(dummyObject), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(dummyObject);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["timeZoneOffset"].ToString(), Is.EqualTo("+00:00"));
        }

        [Test]
        public void PositiveTimeZoneOffsetDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["timeZoneOffset"] = "+03:00";

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw), Throws.Nothing);

            TimeZoneOffsetDummyObject dummyObject = JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.TimeZoneOffset, Is.EqualTo(new TimeSpan(3, 0, 0)));
        }

        [Test]
        public void NegativeTimeZoneOffsetDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["timeZoneOffset"] = "-07:00";

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw), Throws.Nothing);

            TimeZoneOffsetDummyObject dummyObject = JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.TimeZoneOffset, Is.EqualTo(new TimeSpan(-7, 0, 0)));
        }

        [Test]
        public void ZeroTimeZoneOffsetDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["timeZoneOffset"] = "+00:00";

            string dummyObjectRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw), Throws.Nothing);

            TimeZoneOffsetDummyObject dummyObject = JsonConvert.DeserializeObject<TimeZoneOffsetDummyObject>(dummyObjectRaw);

            Assert.That(dummyObject.TimeZoneOffset, Is.EqualTo(TimeSpan.Zero));
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
    }
}
