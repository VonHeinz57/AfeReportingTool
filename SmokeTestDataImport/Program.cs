using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Data;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = new AppConfiguration().ConnectionString;

        var services = new ServiceCollection();
        services.AddDbContext<SmokeTestingDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Other services configuration...

        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SmokeTestingDbContext>();

            // Now you can use dbContext to interact with the database
        }
    }
}
