using EstateAgency.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EstateAgency.Core
{
    public class EstateAgencyDbContext : DbContext
    {

        public EstateAgencyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            builder.UseMySQL(config.GetConnectionString("Svi"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EstateAgencyDbContext).Assembly);
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
