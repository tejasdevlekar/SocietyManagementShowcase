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

        public DbSet<User> Users { get; set; }

    }
}
