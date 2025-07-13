using System.Text.Json;
using Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using Common.Models;
using Common.Common;

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

        public async Task<AmenitiesResponse> GetAmenityInfoAsync(AmenityType type)
        {
            try
            {
                switch (type)
                {
                    case AmenityType.Gym:
                        using (_efCoreDbContext)
                        {
                            int latestId = _efCoreDbContext.Gym
                                .Include(x => x.MaintenaceLog)
                                .AsNoTracking()
                                .FirstOrDefault().MaintenaceLog.LastOrDefault().Id;


                            Gym gym = await _efCoreDbContext.Gym
                                    .Include(x => x.MaintenaceLog
                                    .Where(y => y.Id == latestId))
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
                            gym.LastMaintenanceCheck = gym.MaintenaceLog.LastOrDefault().DateAndTime;

                            AmenitiesResponse response = new AmenitiesResponse();
                            response.Type = AmenityType.Gym;
                            response.Amenity = gym;
                            return response;
                        }
                        break;
                    case AmenityType.SwimmingPoolIndoor:
                        using (_efCoreDbContext)
                        {
                            int latestId = _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Indoor)
                                .Include(x => x.MaintenaceLog)
                                .AsNoTracking()
                                .FirstOrDefault().MaintenaceLog.LastOrDefault().Id;

                            SwimmingPool pool = await _efCoreDbContext.SwimmingPool
                                .Where(x => x.PoolType == SwimmingPoolType.Indoor)
                                .Include(a => a.MaintenaceLog
                                .Where(b => b.Id == latestId))
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            pool.LastMaintenanceCheck = pool.MaintenaceLog.LastOrDefault().DateAndTime;

                            AmenitiesResponse response = new AmenitiesResponse();
                            response.Type = AmenityType.SwimmingPoolIndoor;
                            response.Amenity = pool;
                            return response;
                        }
                        break;
                    case AmenityType.SwimmingPoolOutdoor:
                        using (_efCoreDbContext)
                        {
                                int latestId = _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Outdoor)
                                .Include(x => x.MaintenaceLog)
                                .AsNoTracking()
                                .FirstOrDefault().MaintenaceLog.LastOrDefault().Id;

                            SwimmingPool pool = await _efCoreDbContext.SwimmingPool
                                .Where(x => x.PoolType == SwimmingPoolType.Outdoor)
                                .Include(a => a.MaintenaceLog
                                .Where(b => b.Id == latestId))
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

                            pool.LastMaintenanceCheck = pool.MaintenaceLog.LastOrDefault().DateAndTime;
                           
                            AmenitiesResponse response = new AmenitiesResponse();
                            response.Type = AmenityType.SwimmingPoolIndoor;
                            response.Amenity = pool;
                            return response;

                        }
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


        public async Task<bool> UpdateAmenityInfoAsync(AmenityType type, AmenitiesResponse response)
        {
            try
            {
                switch (type)
                {
                    case AmenityType.Gym:
                        using (_efCoreDbContext)
                        {
                            Gym retrievedGym = await _efCoreDbContext.Gym.FirstOrDefaultAsync();
                            Gym postedGym = JsonSerializer.Deserialize<Gym>(response.Amenity.ToString());
                            if (retrievedGym != null)
                            {
                                retrievedGym.Health = postedGym.Health;
                                await _efCoreDbContext.SaveChangesAsync();
                                return true;
                            }
                            else return false;
                        }
                        break;
                    case AmenityType.SwimmingPoolIndoor:
                        using (_efCoreDbContext)
                        {
                            SwimmingPool retrievedPool = await _efCoreDbContext.SwimmingPool
                                .Where(x => x.PoolType == SwimmingPoolType.Indoor)
                                .FirstOrDefaultAsync();
                            SwimmingPool postedPool = JsonSerializer.Deserialize<SwimmingPool>(response.Amenity.ToString());
                            if (retrievedPool != null)
                            {
                                retrievedPool.Health = postedPool.Health;
                                await _efCoreDbContext.SaveChangesAsync();
                                return true;
                            }
                            else return false;
                        }
                        return false;
                        break;
                    case AmenityType.SwimmingPoolOutdoor:
                        using(_efCoreDbContext)
                        {
                            SwimmingPool retrievedPool = await _efCoreDbContext.SwimmingPool
                                .Where(x => x.PoolType == SwimmingPoolType.Outdoor)
                                .FirstOrDefaultAsync();
                            SwimmingPool postedPool = JsonSerializer.Deserialize<SwimmingPool>(response.Amenity.ToString());
                            if (retrievedPool != null)
                            {
                                retrievedPool.Health = postedPool.Health;
                                await _efCoreDbContext.SaveChangesAsync();
                                return true;
                            }
                            else return false;
                        }
                        return false;
                        break;
                    case AmenityType.CommonAmenitiesMen:
                        return false;
                        break;
                    case AmenityType.CommonAmenitiesWomen:
                        return false;
                        break;
                    default:
                        return false;
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }




    }
}
