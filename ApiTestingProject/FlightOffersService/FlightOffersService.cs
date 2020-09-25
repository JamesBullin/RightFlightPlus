using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TokenAPI;

namespace ApiTestingProject
{
    public class FlightOffersService
    {    
        private readonly FlightOffersCallManager m_flightOffersCallManager;

        public FlightOffersService(ITokenService tokenService)
        {
            m_flightOffersCallManager = new FlightOffersCallManager(tokenService.GetToken());
        }

        public FlightOffersDto GetFlightOffersResult(string originLocationCode, string destinationLocationCode, DateTime departureDate, int adults)
        {
            string rawResult = m_flightOffersCallManager.GetFlightOffersRawResult(originLocationCode, destinationLocationCode, departureDate, adults);

            return JsonConvert.DeserializeObject<FlightOffersDto>(rawResult);
        }
    }
}
