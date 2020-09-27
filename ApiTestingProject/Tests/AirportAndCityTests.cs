using System;
using NUnit.Framework;
using TokenAPI;

namespace ApiTestingProject
{
    [TestFixture]
    public class AirportAndCityTests
    {
        private ITokenService m_tokenService;

        private AirportAndCityDto m_result;

        [OneTimeSetUp]
        public void Setup()
        {
            m_tokenService = new TokenService();

            AirportAndCityService airportAndCityService = new AirportAndCityService(m_tokenService);
            m_result = airportAndCityService.GetAirportAndCityResult(AirportAndCityLoader.LocationType, AirportAndCityLoader.Keyword);
        }

        [Test]
        public void NumberOfResultsIsCorrect()
        {
            Assert.That(m_result.Data.Count, Is.EqualTo(AirportAndCityLoader.ExpectedNumberOfResults));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.SubTypeCases))]
        public void SubTypeIsCorrect(int index, LocationType subType)
        {
            Assert.That(m_result.Data[index].SubType, Is.EqualTo(subType));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.NameCases))]
        public void NameIsCorrect(int index, string name)
        {
            Assert.That(m_result.Data[index].Name, Is.EqualTo(name));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.DetailedNameCases))]
        public void DetailedNameIsCorrect(int index, string detailedName)
        {
            Assert.That(m_result.Data[index].DetailedName, Is.EqualTo(detailedName));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.IdCases))]
        public void IdIsCorrect(int index, string id)
        {
            Assert.That(m_result.Data[index].Id, Is.EqualTo(id));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.TimeZoneOffsetCases))]
        public void TimeZoneOffsetIsCorrect(int index, TimeSpan timeZoneOffset)
        {
            Assert.That(m_result.Data[index].TimeZoneOffset, Is.EqualTo(timeZoneOffset));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.IataCodeCases))]
        public void IataCodeIsCorrect(int index, string iataCode)
        {
            Assert.That(m_result.Data[index].IataCode, Is.EqualTo(iataCode));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.GeoCodeCases))]
        public void GeoCodeIsCorrect(int index, float latitude, float longitude)
        {
            Assert.That(m_result.Data[index].GeoCode.Latitude, Is.EqualTo(latitude));
            Assert.That(m_result.Data[index].GeoCode.Longitude, Is.EqualTo(longitude));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.CityCases))]
        public void CityIsCorrect(int index, string cityName, string cityCode)
        {
            Assert.That(m_result.Data[index].Address.CityName, Is.EqualTo(cityName));
            Assert.That(m_result.Data[index].Address.CityCode, Is.EqualTo(cityCode));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.CountryCases))]
        public void CountryIsCorrect(int index, string countryName, string countryCode)
        {
            Assert.That(m_result.Data[index].Address.CountryName, Is.EqualTo(countryName));
            Assert.That(m_result.Data[index].Address.CountryCode, Is.EqualTo(countryCode));
        }

        [TestCaseSource(typeof(AirportAndCityLoader), nameof(AirportAndCityLoader.RegionCases))]
        public void RegionIsCorrect(int index, string regionCode)
        {
            Assert.That(m_result.Data[index].Address.RegionCode, Is.EqualTo(regionCode));
        }
    }
}
