using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TokenAPI
{
    public class TokenService : ITokenService
    {
        // Instance of call manager. Manages call to API and gets data
        internal TokenCallManager TokenCallManager { get; set; } = new TokenCallManager();

        // Last set of rates received
        internal TokenModel LastToken { get; set; }

        // JObject: Last rates received
        internal JObject JsonToken { get; set; }

        public TokenService()
        {
            // Store string from API call made by TokenCallManager

            string lastToken = TokenCallManager.GetToken();

            LastToken = JsonConvert.DeserializeObject<TokenModel>(lastToken);

            JsonToken = JsonConvert.DeserializeObject<JObject>(lastToken);
        }

        public string GetToken()
        {
            return LastToken.access_token.ToString();
        }
    }
}
