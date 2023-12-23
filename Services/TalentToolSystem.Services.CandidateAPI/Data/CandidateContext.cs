
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TalentToolSystem.Services.CandidateAPI.Model;
using static System.Net.Mime.MediaTypeNames;

namespace TalentToolSystem.Services.CandidateAPI.Data
{
    public class CandidateContext : DbContext

    {
        public CandidateContext(DbContextOptions<CandidateContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                CandidateId = 1,
                CandidateName = "Indresh Kumar Maurya",
                Email = "indresh@gmail.com",
                Mobile = "7823637281",
                CurrentCompany = "Nexturn",
                SkillSet = "C++,.Net,Sql Server",
                YearOfExperience = 1,
                Location = "Mirzapur",
                CTC = 10,
                ECTC = 10,
                NoticePeriod = 10,
                ReferralId = 101,
                Status = "Selected",
                Manager = "Gunjan",
                Account = "Salesforce"
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                CandidateId = 2,
                CandidateName = "Shobhit Kumar Singh",
                Email = "shobhit@gmail.com",
                Mobile = "7823637281",
                CurrentCompany = "Nexturn",
                SkillSet = "C++,.Net,Sql Server",
                YearOfExperience = 1,
                Location = "Patna",
                CTC = 10,
                ECTC = 10,
                NoticePeriod = 10,
                ReferralId = 101,
                Status = "Selected",
                Manager = "Gunjan",
                Account = "Salesforce"
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                CandidateId = 3,
                CandidateName = "Abuzar Nasim",
                Email = "abuzar@gmail.com",
                Mobile = "7823637281",
                CurrentCompany = "Nexturn",
                SkillSet = "C++,.Net,Sql Server",
                YearOfExperience = 1,
                Location = "Ranchi",
                CTC = 10,
                ECTC = 10,
                NoticePeriod = 10,
                ReferralId = 101,
                Status = "Selected",
                Manager = "Gunjan",
                Account = "Amazon"
            });
        }
        
    }
}
