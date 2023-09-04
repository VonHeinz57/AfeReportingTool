using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Data;
using AfeReportingTool.Services;
using AfeReportingTool.Templates;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = new AppConfiguration().connectionString;
        var outputDirectory = new AppConfiguration().outputDirectory;

        var services = new ServiceCollection();
        services.AddDbContext<SmokeTestingDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<SmokeTestImportService>();
        services.AddScoped<SmokeTestExportService>();
        services.AddScoped<SmokeTestReportTemplate>();


        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SmokeTestingDbContext>();
            var smokeTestImportService = scope.ServiceProvider.GetRequiredService<SmokeTestImportService>();
            var smokeTestExportService = scope.ServiceProvider.GetRequiredService<SmokeTestExportService>();
            var smokeTestReportTemplate = scope.ServiceProvider.GetRequiredService<SmokeTestReportTemplate>();

            smokeTestImportService.ImportFiles(dbContext);
            smokeTestExportService.ExportReports(outputDirectory, dbContext);
        }
    }
}
