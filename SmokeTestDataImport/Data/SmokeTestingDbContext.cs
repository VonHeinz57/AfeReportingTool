using System;
using SmokeTestDataImport.Models;
using Microsoft.EntityFrameworkCore;
using SmokeTestDataImport.Configs;

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

