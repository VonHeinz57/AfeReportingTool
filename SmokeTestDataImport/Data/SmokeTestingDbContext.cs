using Microsoft.EntityFrameworkCore;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Models;

namespace SmokeTestDataImport.Data
{
    public class SmokeTestingDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new AppConfiguration().ConnectionString;

            // Configure the database connection here
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<SmokeDefect> SmokeDefects { get; set; }
	}
}

