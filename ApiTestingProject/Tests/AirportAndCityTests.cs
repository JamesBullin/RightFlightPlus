using System;
using NUnit.Framework;
using TokenAPI;

namespace ApiTestingProject
{
    [TestFixture]
    public class AirportAndCityTests
    {
        ITokenService token = new TokenService();

        LocationType testLocationType = LocationType.Airport;
        string testKeyword = "london";

        AirportAndCityService request;
        AirportAndCityDto result;

        [OneTimeSetUp]
        public void Setup()
        {
            request = new AirportAndCityService(token);
            result = request.GetAirportAndCityResult(testLocationType, testKeyword);
        }

        [Test]
        public void NumberOfResultsIsCorrect()
        {
            int expectedNumResults = 10;
            Assert.That(result.Data.Count, Is.EqualTo(expectedNumResults));
        }

        [Test]
        public void SubTypeIsCorrect()
        {
            foreach(Location a in result.Data)
            {
                Assert.That(a.SubType, Is.EqualTo(LocationType.Airport));
            }
        }

        [Test]
        public void NameIsCorrect()
        {
            Assert.That(result.Data[0].Name, Is.EqualTo("HEATHROW"));
            Assert.That(result.Data[1].Name, Is.EqualTo("GATWICK"));
            Assert.That(result.Data[2].Name, Is.EqualTo("STANSTED"));
            Assert.That(result.Data[3].Name, Is.EqualTo("LUTON"));
        }

        [Test]
        public void DetailedNameIsCorrect()
        {
            Assert.That(result.Data[0].DetailedName, Is.EqualTo("LONDON/GB:HEATHROW"));
            Assert.That(result.Data[1].DetailedName, Is.EqualTo("LONDON/GB:GATWICK"));
            Assert.That(result.Data[2].DetailedName, Is.EqualTo("LONDON/GB:STANSTED"));
            Assert.That(result.Data[3].DetailedName, Is.EqualTo("LONDON/GB:LUTON"));
        }

        [Test]
        public void IdIsCorrect()
        {
            Assert.That(result.Data[0].Id, Is.EqualTo("ALHR"));
            Assert.That(result.Data[1].Id, Is.EqualTo("ALGW"));
            Assert.That(result.Data[2].Id, Is.EqualTo("ASTN"));
            Assert.That(result.Data[3].Id, Is.EqualTo("ALTN"));
        }

        [Test]
        public void TimeZoneOffsetIsCorrect()
        {
            Assert.That(result.Data[0].TimeZoneOffset, Is.EqualTo(new TimeSpan(1, 0, 0)));
            Assert.That(result.Data[1].TimeZoneOffset, Is.EqualTo(new TimeSpan(1, 0, 0)));
            Assert.That(result.Data[2].TimeZoneOffset, Is.EqualTo(new TimeSpan(1, 0, 0)));
            Assert.That(result.Data[3].TimeZoneOffset, Is.EqualTo(new TimeSpan(1, 0, 0)));
        }

        [Test]
        public void IataCodeIsCorrect()
        {
            Assert.That(result.Data[0].IataCode, Is.EqualTo("LHR"));
            Assert.That(result.Data[1].IataCode, Is.EqualTo("LGW"));
            Assert.That(result.Data[2].IataCode, Is.EqualTo("STN"));
            Assert.That(result.Data[3].IataCode, Is.EqualTo("LTN"));
        }

        [Test]
        public void GeoCodeIsCorrect()
        {
            Assert.That(result.Data[0].GeoCode.Latitude, Is.EqualTo(51.47294f));
            Assert.That(result.Data[0].GeoCode.Longitude, Is.EqualTo(-0.45061f));

            Assert.That(result.Data[1].GeoCode.Latitude, Is.EqualTo(51.15609f));
            Assert.That(result.Data[1].GeoCode.Longitude, Is.EqualTo(-0.17818f));

            Assert.That(result.Data[2].GeoCode.Latitude, Is.EqualTo(51.88500f));
            Assert.That(result.Data[2].GeoCode.Longitude, Is.EqualTo(0.23500f));

            Assert.That(result.Data[3].GeoCode.Latitude, Is.EqualTo(51.87472f));
            Assert.That(result.Data[3].GeoCode.Longitude, Is.EqualTo(-0.36833f));
        }

        [Test]
        public void CityIsCorrect()
        {
            for (int i = 0; i < 4; ++i)
            {
                Assert.That(result.Data[i].Address.CityName, Is.EqualTo("LONDON"));
                Assert.That(result.Data[i].Address.CityCode, Is.EqualTo("LON"));
            }
        }

        [Test]
        public void CountryIsCorrect()
        {
            for (int i = 0; i < 4; ++i)
            {
                Assert.That(result.Data[i].Address.CountryName, Is.EqualTo("UNITED KINGDOM"));
                Assert.That(result.Data[i].Address.CountryCode, Is.EqualTo("GB"));
            }
        }

        [Test]
        public void RegionIsCorrect()
        {
            for (int i = 0; i < 4; ++i)
            {
                Assert.That(result.Data[i].Address.RegionCode, Is.EqualTo("EUROP"));
            }
        }
    }
}
