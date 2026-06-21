using Microsoft.EntityFrameworkCore;
using OCMS_project.Models;
using OCMS_project.Seeding;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OCMS_project.Areas.Visitors.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = ConfigurationManager.ConnectionStrings["default-Connection"]?.ConnectionString;
                if (string.IsNullOrEmpty(conn))
                {
                    throw new InvalidOperationException("Connection string 'default-Connection' not found. ");
                }

                optionsBuilder.UseSqlServer(conn);
            }
        }


        public DbSet<Models.Users> Users { get; set; }
        public DbSet<UserCreadential> UserCreadentials { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Complaints> Complaints { get; set; }


        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<OCMS_project.Models.Category>().HasData(CategorySeeding.SeedData());

                modelBuilder.Entity<OCMS_project.Models.Users>().HasData(AccountSeeding.UserSeeding());

                modelBuilder.Entity<OCMS_project.Models.UserRoles>().HasData(AccountSeeding.UserRoleSeeding());

                modelBuilder.Entity<OCMS_project.Models.UserCreadential>().HasData(AccountSeeding.UserCreadentialSeeding());


            }

        }
    }
}