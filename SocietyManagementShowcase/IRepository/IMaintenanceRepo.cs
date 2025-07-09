using Common;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IMaintenanceRepo
    {
        Task<List<MaintenanceLog>> GetMaintenanceLogAsync(MaintenanceLogType type, int lastId);
        Task<bool> PostMaintenanceLogAsync(MaintenanceLogType type, MaintenanceLog log);
    }
}