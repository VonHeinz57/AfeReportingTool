using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Data;
using SmokeTestDataImport.Services;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = new AppConfiguration().connectionString;

        var services = new ServiceCollection();
        services.AddDbContext<SmokeTestingDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<SmokeTestImportService>();


        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SmokeTestingDbContext>();
            var smokeTestImportService = scope.ServiceProvider.GetRequiredService<SmokeTestImportService>();

            smokeTestImportService.ImportFiles(dbContext);
        }

        
    }
}
