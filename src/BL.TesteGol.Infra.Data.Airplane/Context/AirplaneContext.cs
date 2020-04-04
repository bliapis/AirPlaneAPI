using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using BL.TesteGol.Infra.Data.Airplane.Mappings;

namespace BL.TesteGol.Infra.Data.Airplane.Context
{
    public class AirplaneContext : DbContext
    {
        public DbSet<AirplaneModel> AirPlanes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirplaneModelMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}