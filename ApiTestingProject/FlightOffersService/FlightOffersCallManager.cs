using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiTestingProject
{
    public class FlightOffersCallManager
    {
        private readonly string m_authorizationToken;

        private readonly RestClient m_client;

        public FlightOffersCallManager(string authorizationToken)
        {
            m_authorizationToken = authorizationToken;

            m_client = new RestClient(ConfigReader.FlightOffersBaseUrl);
        }

        public string GetFlightOffersRawResult(string originLocationCode, string destinationLocationCode, DateTime departureDate, int adults)
        {
            RestRequest request = new RestRequest("shopping/flight-offers", Method.GET);

            request.AddHeader("Authorization", $"Bearer {m_authorizationToken}");

            request.AddParameter("originLocationCode", originLocationCode);
            request.AddParameter("destinationLocationCode", destinationLocationCode);
            request.AddParameter("departureDate", departureDate.ToString("yyyy-MM-dd"));
            request.AddParameter("adults", adults);

            request.AddParameter("travelClass", "ECONOMY");
            request.AddParameter("nonStop", "true");
            request.AddParameter("currencyCode", "GBP");
            request.AddParameter("max", 5);

            IRestResponse response = m_client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Error in request: {response.ErrorMessage}");

            return response.Content;
        }
    }
}
