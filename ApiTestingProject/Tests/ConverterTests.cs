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
            Segment segment = new Segment
            {
                AircraftCode = "737"
            };

            Assert.That(() => JsonConvert.SerializeObject(segment), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(segment);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["aircraft"]["code"].ToString(), Is.EqualTo("737"));
        }

        [Test]
        public void OperatorSerializedCorrectly()
        {
            Segment segment = new Segment
            {
                OperatorCode = "BA"
            };

            Assert.That(() => JsonConvert.SerializeObject(segment), Throws.Nothing);

            string serializedJson = JsonConvert.SerializeObject(segment);

            JObject j = JObject.Parse(serializedJson);

            Assert.That(j["operating"]["carrierCode"].ToString(), Is.EqualTo("BA"));
        }

        [Test]
        public void AircraftDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["aircraft"] = new JObject();

            j["aircraft"]["code"] = "737";

            string segmentRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<Segment>(segmentRaw), Throws.Nothing);

            Segment segment = JsonConvert.DeserializeObject<Segment>(segmentRaw);

            Assert.That(segment.AircraftCode, Is.EqualTo("737"));
        }

        [Test]
        public void OperatorDeserializedCorrectly()
        {
            JObject j = new JObject();
            j["operating"] = new JObject();

            j["operating"]["carrierCode"] = "BA";

            string segmentRaw = j.ToString();

            Assert.That(() => JsonConvert.DeserializeObject<Segment>(segmentRaw), Throws.Nothing);

            Segment segment = JsonConvert.DeserializeObject<Segment>(segmentRaw);

            Assert.That(segment.OperatorCode, Is.EqualTo("BA"));
        }
    }
}
