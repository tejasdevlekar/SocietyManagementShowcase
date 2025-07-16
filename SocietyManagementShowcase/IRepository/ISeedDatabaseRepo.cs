using Common.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface ISeedDatabaseRepo
    {
        Task<Society> SeedDatabaseAsync();
    }
}