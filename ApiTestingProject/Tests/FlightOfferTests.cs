using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAPI;

namespace ApiTestingProject
{
    class FlightOfferTests
    {
        [TestFixture]
        public class AirportAndCityTests
        {
            ITokenService token = new TokenService();

            string originLocationCode = "LHR";
            string destinationLocationCode = "JFK";
            DateTime departureDate = new DateTime(2020, 10, 01);
            int numAdults = 1;

            FlightOffersService request;
            FlightOffersDto result;

            [OneTimeSetUp]
            public void Setup()
            {
                request = new FlightOffersService(token);
                result = request.GetFlightOffersResult(originLocationCode, destinationLocationCode, departureDate, numAdults);
            }

            [Test]
            public void IsExceptionThrown()
            {
            }

            [Test]
            public void NumberOfResultsIsCorrect()
            {
                int expectedNumResults = 10;
                Assert.That(result.Data.Count, Is.EqualTo(expectedNumResults));
            }
        }
    }
}
