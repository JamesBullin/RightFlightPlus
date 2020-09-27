using System;
using System.Configuration;

namespace ApiTestingProject
{
    public static class ConfigReader
    {
        public static readonly string AirportCityBaseUrl = ConfigurationManager.AppSettings["airport_and_city_base_url"];
        public static readonly string FlightOffersBaseUrl = ConfigurationManager.AppSettings["flight_offers_base_url"];
    }
}
