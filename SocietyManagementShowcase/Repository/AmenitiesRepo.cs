using Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.Repository
{
    public class AmenitiesRepo : IAmenitiesRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<AmenitiesRepo> _logger;

        public AmenitiesRepo(EfCoreDbContext efCoreDbContext, ILogger<AmenitiesRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<Gym> GetAmenityInfoAsync(AmenityType type)
        {
            try
            {
                switch (type)
                {
                    case AmenityType.Gym:
                        using (_efCoreDbContext)
                        {
                            int latestId = _efCoreDbContext.Gym
                                .Include(x => x.GymMaintenaceLog)
                                .AsNoTracking()
                                .FirstOrDefault().GymMaintenaceLog.LastOrDefault().Id;


                            Gym gym = await _efCoreDbContext.Gym
                                    .Include(x => x.GymMaintenaceLog
                                    .Where(y => y.Id == latestId))
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
                            gym.LastMaintenanceCheck = gym.GymMaintenaceLog.LastOrDefault().DateAndTime;

                            return gym;
                        }
                        break;
                    case AmenityType.SwimmingPoolOutdoor:
                        return null; //temp change later
                        break;
                    case AmenityType.SwimmingPoolIndoor:
                        return null; //temp change later
                        break;
                    case AmenityType.CommonAmenitiesMen:
                        return null; //temp change later
                        break;
                    case AmenityType.CommonAmenitiesWomen:
                        return null; //temp change later
                        break;
                    default:
                        return null;
                        break;
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
