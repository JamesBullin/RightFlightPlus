using System;
using Newtonsoft.Json;

namespace ApiTestingProject
{
    public class AirportAndCityService
    {
        private readonly AirportAndCityCallManager m_airportAndCityCallManager;

        public AirportAndCityService(ITokenService tokenService)
        {
            m_airportAndCityCallManager = new AirportAndCityCallManager(tokenService.GetToken());
        }

        public AirportAndCityDto GetAirportAndCityResult(LocationType subType, string keyword)
        {
            string rawResult = m_airportAndCityCallManager.GetAirportAndCityRawResult(subType, keyword);

            return JsonConvert.DeserializeObject<AirportAndCityDto>(rawResult);
        }
    }
}
