using System;
using System.Configuration;

namespace TokenAPI
{
    public static class ConfigReader
    {
        public static readonly string TokenBaseUrl = ConfigurationManager.AppSettings["token_base_url"];
        public static readonly string GrantType = ConfigurationManager.AppSettings["grant_type"];
        public static readonly string ClientID = ConfigurationManager.AppSettings["client_id"];
        public static readonly string ClientSecret = ConfigurationManager.AppSettings["client_secret"];
    }
}
