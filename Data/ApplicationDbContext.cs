using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_pract.Data.Models;

namespace web_api_pract.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project_Devloper>()
                .HasOne(d => d.devloper)
                .WithMany(p => p.project_devlopers)
                .HasForeignKey(di=>di.DevloperId);

            modelBuilder.Entity<Project_Devloper>()
               .HasOne(p=> p.project)
               .WithMany(p => p.project_devlopers)
               .HasForeignKey(pi => pi.ProjectId);



        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Devloper> Devlopers { get; set; }
        public DbSet<Project_Devloper> Project_Devlopers { get; set; }
       
    }
}
