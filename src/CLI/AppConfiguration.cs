using Microsoft.Extensions.Configuration;
using System.IO;

namespace CLI
{
    static class AppConfiguration
    {
        public static IConfigurationRoot UseConfigSettings() => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

    }
}
