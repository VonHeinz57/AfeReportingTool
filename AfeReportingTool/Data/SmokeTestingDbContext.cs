using Microsoft.EntityFrameworkCore;
using SmokeTestDataImport.Configs;
using SmokeTestDataImport.Models;

namespace SmokeTestDataImport.Data
{
    public class SmokeTestingDbContext : DbContext
	{
        //Can't run ef migration with both of these here.... need to fix how I'm connecting I guess?
        public SmokeTestingDbContext(DbContextOptions<SmokeTestingDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new AppConfiguration().connectionString;

                // Configure the database connection here
                optionsBuilder.UseNpgsql(connectionString);
            }
                
        }

        public DbSet<SmokeDefect> SmokeDefects { get; set; }
	}
}

