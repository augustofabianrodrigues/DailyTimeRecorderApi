using DailyTimeRecorder.Domain.Core.Interfaces;
using DailyTimeRecorder.Domain.Models;
using DailyTimeRecorder.Infra.Data.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DailyTimeRecorder.Infra.Data.EntityFramework.Context
{
    public sealed class DailyTimeRecorderContext : DbContext, IDbContext
    {
        public DbSet<Analyst> Analysts { get; set; }

        public DailyTimeRecorderContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnalystMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
