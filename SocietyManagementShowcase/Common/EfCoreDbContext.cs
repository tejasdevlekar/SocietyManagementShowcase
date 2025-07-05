using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.Common
{
    public class EfCoreDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SocietyManagement;User Id=Tejas;Password=password123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Flat>()
            //    .HasMany(e => e.Residents)
            //    .WithOne(e => e.Flat)
            //    .HasForeignKey(e => e.FlatId)
            //    .IsRequired();


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Society> Society { get; set; }

    }
}
