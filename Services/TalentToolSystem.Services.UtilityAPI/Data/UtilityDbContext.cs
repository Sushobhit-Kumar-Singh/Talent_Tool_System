using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Reflection.Emit;
using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Data
{
    public class UtilityDbContext : DbContext
    {
        public UtilityDbContext(DbContextOptions<UtilityDbContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(new Location
            {
                LocationId = 1,
                City = "Allahabad",
                State = "UP"
            });

            modelBuilder.Entity<Location>().HasData(new Location
            {
                LocationId = 2,
                City = "Varanasi",
                State = "UP"
            });

            modelBuilder.Entity<Location>().HasData(new Location
            {
                LocationId = 3,
                City = "Mirzapur",
                State = "UP"
            });
        }
    }
}
