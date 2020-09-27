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
        public void NameIsCorrect()
        {
            Assert.That(result.Data[0].Name, Is.EqualTo("HEATHROW"));
        }

        [Test]
        public void DetailedNameIsCorrect()
        {
            Assert.That(result.Data[0].DetailedName, Is.EqualTo("LONDON/GB:HEATHROW"));
        }

        [Test]
        public void IdIsCorrect()
        {
            Assert.That(result.Data[0].Id, Is.EqualTo("ALHR"));
        }

        [Test]
        public void TimeZoneOffsetIsCorrect()
        {
            Assert.That(result.Data[0].TimeZoneOffset, Is.EqualTo("+01:00"));
        }

        [Test]
        public void GeoCodeIsCorrect()
        {
            Assert.That(result.Data[0].GeoCode.Latitude, Is.EqualTo(51.47294f));
            Assert.That(result.Data[0].GeoCode.Longitude, Is.EqualTo(-0.45061f));
        }

        [Test]
        public void CityIsCorrect()
        {
            Assert.That(result.Data[0].Address.CityName, Is.EqualTo("LONDON"));
            Assert.That(result.Data[0].Address.CityCode, Is.EqualTo("LON"));
        }

        [Test]
        public void CountryIsCorrect()
        {
            Assert.That(result.Data[0].Address.CountryName, Is.EqualTo("UNITED KINGDOM"));
            Assert.That(result.Data[0].Address.CountryCode, Is.EqualTo("GB"));
        }

        [Test]
        public void RegionIsCorrect()
        {
            Assert.That(result.Data[0].Address.RegionCode, Is.EqualTo("EUROP"));
        }
    }
}
