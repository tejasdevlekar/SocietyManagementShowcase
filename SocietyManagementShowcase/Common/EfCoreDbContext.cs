using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using Common.Common;

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
        public DbSet<Wing> Wing { get; set; }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLog { get; set; }
        public DbSet<SwimmingPool> SwimmingPool { get; set; }
        public DbSet<CommonAmenities> CommonAmenities { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<WaterTank> WaterTank { get; set; }
        public DbSet<FireFightingSystem> FireFightingSystem { get; set; }
        public DbSet<WaterFiltrationSystem> WaterFiltrationSystem { get; set; }
        public DbSet<MySessionModel> MySessionModel { get; set; }


    }
}
