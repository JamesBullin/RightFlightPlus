using RestSharp;
using System;
using System.Collections.Generic;

namespace ApiTestingProject
{
    public class AirportAndCityCallManager
    {
        private readonly string m_authorizationToken;

        private readonly RestClient m_client;

        public AirportAndCityCallManager(string authorizationToken)
        {
            m_authorizationToken = authorizationToken;
            
            m_client = new RestClient(ConfigReader.BaseUrl);
        }

        public string GetAirportAndCityRawResult(LocationType subType, string keyword)
        {
            string subTypeParameter;

            //The encoded values of this enum allow you to choose both Airport and City. If this is the case then the string representation sent as a parameter
            //to the API needs to be a comma-separated list.
            if (subType == (LocationType.Airport | LocationType.City))
                subTypeParameter = LocationType.Airport.ToString() + ',' + LocationType.City.ToString();
            else
                subTypeParameter = subType.ToString();

            RestRequest request = new RestRequest("reference-data/locations", Method.GET);

            request.AddHeader("Authorization", $"Bearer {m_authorizationToken}");

            request.AddParameter("subType", subType.ToString());
            request.AddParameter("keyword", keyword);

            return m_client.Execute(request).Content;
        }
    }
}
