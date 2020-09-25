using RestSharp;
using System;
using System.Collections.Generic;

namespace TokenAPI
{
    internal class TokenCallManager
    {
        // Test restSharp object that handles the call
        readonly IRestClient _client;

        public TokenCallManager()
        {
            _client = new RestClient(ConfigReader.TokenBaseUrl);
        }
        internal string GetToken()
        {
            var request = new RestRequest();
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type={ConfigReader.GrantType}&client_id={ConfigReader.ClientID}&client_secret={ConfigReader.ClientSecret}", ParameterType.RequestBody);
            var response = _client.Execute(request, Method.POST);
            return response.Content;
        }

        internal string GetStatusCode()
        {
            var request = new RestRequest();
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type={ConfigReader.GrantType}&client_id={ConfigReader.ClientID}&client_secret={ConfigReader.ClientSecret}", ParameterType.RequestBody);
            var response = _client.Execute(request, Method.POST);
            return response.StatusCode.ToString();
        }
    }
}
