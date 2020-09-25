using System;
using System.Configuration;

namespace ApiTestingProject
{
    public static class ConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
    }
}
