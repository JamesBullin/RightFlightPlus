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
            DateTime departureDate = (DateTime.Now.AddDays(10));
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
            public void NumberOfResultsIsCorrect()
            {
                int expectedNumResults = 5;
                Assert.That(result.Data.Count, Is.EqualTo(expectedNumResults));
            }

            [Test]
            public void IDIsNumerical()
            {
                    Assert.That(result.Data[0].Id, Is.AtLeast(0));
            }

            [Test]
            public void LastTicketingDateIsInFuture()
            {
                DateTime departureTime = result.Data[0].Itineraries[0].Segments[0].Departure.Time;
                Assert.That(result.Data[0].LastTicketingDate, Is.InRange(DateTime.Now, departureTime));
            }

            [Test]
            public void NumBookableSeatsIsNumerical()
            {
                Assert.That(result.Data[0].NumberOfBookableSeats, Is.InRange(0, 1000));
            }

            [Test]
            public void AtLeastOneItinerary()
            {
                Assert.That(result.Data[0].Itineraries.Count, Is.AtLeast(1));
            }

            [Test]
            public void ItineraryDurationIsNumerical()
            {
                TimeSpan minimumDuration = TimeSpan.FromMinutes(1.0);
                TimeSpan maximumDuration = TimeSpan.FromDays(2.0);
                Assert.That(result.Data[0].Itineraries[0].Duration, Is.AtLeast(minimumDuration));
            }

            [Test]
            public void AtLeastOneSegment()
            {
                Assert.That(result.Data[0].Itineraries[0].Segments.Count, Is.AtLeast(1));
            }
        }
    }
}
