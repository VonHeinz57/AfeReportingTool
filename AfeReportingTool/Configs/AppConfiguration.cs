using Microsoft.Extensions.Configuration;

namespace SmokeTestDataImport.Configs
{
    public class AppConfiguration
    {
        public string connectionString { get; }
        public string workingDirectory { get; }
        public string archiveDirectory { get; }
        public string dataSheetFormat { get; }


        public AppConfiguration(string configFile = "Configs/appsettings.json")
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFile)
                .Build();

            connectionString = configuration.GetSection("SmokeTestingDb").Value;

            workingDirectory = configuration.GetSection("WorkingDirectory").Value;
            archiveDirectory = configuration.GetSection("ArchiveDirectory").Value;

            //Indexes on Smoke Data files
            dataSheetFormat = configuration.GetSection("DataSheetFormat").Value;
        }
    }

}

