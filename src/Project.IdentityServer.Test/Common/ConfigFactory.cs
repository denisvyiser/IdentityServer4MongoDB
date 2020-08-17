using Microsoft.Extensions.Configuration;
using System.IO;

namespace Project.identityserver.Test.Common
{
    public static class ConfigFactory
    {
        private static IConfigurationRoot _config;

        public static IConfigurationRoot BuildConfig()
        {
            if (_config != null) return _config;

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return _config;
        }
    }
}