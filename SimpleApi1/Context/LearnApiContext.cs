using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

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
                d.Property(s => s.FirstName).HasMaxLength(32);
                d.Property(s => s.LastName).HasMaxLength(32);
                d.Property(s => s.UserName).HasMaxLength(32);               
                d.HasMany(s => s.UserRoles).WithOne(s => s.User).HasForeignKey(s => s.UserId);
               // d.Property(s => s.CreateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(d=>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Name).HasMaxLength(32);
                d.HasMany(s => s.UserRoles).WithOne(s => s.Role).HasForeignKey(s => s.Roleid);
            });

            modelBuilder.Entity<UserRole>(d =>
            {
                d.HasKey(s => s.Id);
             //   d.HasOne(s => s.User).WithMany(s => s.UserRoles).HasForeignKey(s => s.UserId);
             //   d.HasOne(s => s.Role).WithMany(s => s.UserRoles).HasForeignKey(s => s.Roleid);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
