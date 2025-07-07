using Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.Repository
{
    public class MaintenanceRepo : IMaintenanceRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<MaintenanceRepo> _logger;

        public MaintenanceRepo(EfCoreDbContext efCoreDbContext, ILogger<MaintenanceRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<List<MaintenanceLog>> GetMaintenanceLogAsync(MaintenanceLogType type)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    switch (type)
                    {
                        case MaintenanceLogType.Gym:
                            Gym gym = await _efCoreDbContext.Gym
                                .Include(x => x.GymMaintenaceLog.OrderByDescending(y => y.DateAndTime))
                                .AsNoTracking()
                                .FirstOrDefaultAsync(); //Since there's only 1 Gym
                            return gym.GymMaintenaceLog;
                            break;
                        case MaintenanceLogType.SwimmingPool:
                            return null; //change later
                            break;
                        case MaintenanceLogType.CommonAmenities:
                            return null; //change later
                            break;
                        default:
                            return null; //change later
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
