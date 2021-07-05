using LawEnforcement.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<LawEnf> LawEnfs { get; set; }
        public DbSet<CrimeEvent> CrimeEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<LawEnf>().HasData(new LawEnf
            {
                LawEnfId = "1",
                RankOfLawEnforcement = Models.Dto.RankOfLawEnforcement.Police,

                
            });
            modelBuilder.Entity<LawEnf>().HasData(new LawEnf
            {
                LawEnfId = "2",
                RankOfLawEnforcement = Models.Dto.RankOfLawEnforcement.Detective,
            });
            modelBuilder.Entity<LawEnf>().HasData(new LawEnf
            {
                LawEnfId = "3",
                RankOfLawEnforcement = Models.Dto.RankOfLawEnforcement.Sheriff,
            });
        }
    }
}
