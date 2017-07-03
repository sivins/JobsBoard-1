using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using reverseJobsBoard.Models;
using reverseJobsBoard.Config;

namespace reverseJobsBoard.Models
{
    public class TDBContext : DbContext
    {
        //Example
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles {get; set;}
        public DbSet<Org> Orgs {get;set;}
    
        //For migrations you have to specify many to many relationships here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserID, t.RoleID });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleID);

            modelBuilder.Entity<UserOrg>()
                .HasKey(t => new { t.UserID, t.OrgID });

            modelBuilder.Entity<UserOrg>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserOrgs)
                .HasForeignKey(pt => pt.UserID);

            modelBuilder.Entity<UserOrg>()
                .HasOne(pt => pt.Org)
                .WithMany(t => t.UserOrgs)
                .HasForeignKey(pt => pt.OrgID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            TestConfigs config = new TestConfigs();
            optionsBuilder.UseSqlServer(@config.testDBUrl);
        }
    }

}