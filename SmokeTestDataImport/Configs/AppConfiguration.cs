using Microsoft.Extensions.Configuration;

namespace SmokeTestDataImport.Configs
{
    public class AppConfiguration
    {
        public string ConnectionString { get; }

        public AppConfiguration(string configFile = "Configs/appsettings.json")
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile)
                .Build();

            ConnectionString = configuration.GetSection("SmokeTestingDb").Value;
        }
    }

}

