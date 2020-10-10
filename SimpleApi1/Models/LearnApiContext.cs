﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Models
{
    public class LearnApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.12.109;Database=LearnApi;User Id=sa;Password=aA123456");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.NationalCode).HasMaxLength(10);
                d.HasMany(s => s.UserRoles).WithOne(s => s.User).HasForeignKey(s => s.UserId);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
