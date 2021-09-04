using Microsoft.Extensions.Configuration;

namespace StarWars.Extensions
{
    public static class ConfigExtensions
    {
        public static string GetApiUrl(this IConfiguration configuration)
        {
            return configuration.GetSection("StarWarsApi").GetValue<string>("ApiUrl");
        }

        public static string GetProxyUrl(this IConfiguration configuration)
        {
            return configuration.GetSection("StarWarsApi").GetValue<string>("ProxyUrl");
        }

        public static int GetProxyPort(this IConfiguration configuration)
        {
            if (int.TryParse(configuration.GetSection("StarWarsApi").GetValue<string>("ProxyPort"), out int port))
            {
                return port;
            }
            return 80;
        }

        public static string GetOutputPath(this IConfiguration configuration)
        {
            return configuration.GetSection("Paths").GetValue<string>("JsonOutput");
        }
    }
}
