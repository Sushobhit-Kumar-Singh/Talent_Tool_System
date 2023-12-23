using System;
using System.Collections.Generic; 
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentToolSystem.Services.DemandAPI.Model;
using Microsoft.Extensions.Options;

namespace TalentToolSystem.Services.DemandAPI.Data
{
    public class DemandContext:DbContext
    {

        public DemandContext(DbContextOptions<DemandContext> options) : base(options)
        {

        }

       
        public DbSet<Demand> demands { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 1,
                DemandName = "Python Developer",
                Email = "nexturn@gmail.com",
                AccountName = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "Python, Relationa Database",
                Location = "Hyderabad"
            });

            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 2,
                DemandName = "Java Developer",
                Email = "nexturn@gmail.com",
                AccountName = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "Python, Relationa Database",
                Location = "Hyderabad"
            });

            modelBuilder.Entity<Demand>().HasData(new Demand
            {
                DemandId = 3,
                DemandName = ".Net Developer",
                Email = "nexturn@gmail.com",
                AccountName = "Amazon",
                Manager = "Gunjan",
                OpenPosition = 1,
                Experience = 1,
                MaxBudget = 10,
                NoticePeriod = 2,
                EmployeeType = "FTE",
                Status = "Selected",
                Skills = "Python, Relationa Database",
                Location = "Hyderabad"
            });
        }
    }
}
