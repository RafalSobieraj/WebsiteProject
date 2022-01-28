using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteProject.Models;

namespace WebsiteProject.Data
{

    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
            
        }
        
        public DbSet<Cameras> Cameras { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasMany(u => u.User)
                .WithOne(r => r.Role)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.Users)
                .WithOne(i => i.UserInfo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}