using Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using Common.Models;
using Common.Common;

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

        public async Task<List<MaintenanceLog>> GetMaintenanceLogAsync(MaintenanceLogType type, int lastId)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    switch (type)
                    {
                        case MaintenanceLogType.Gym:
                            if (lastId == 0)
                            {
                                lastId = _efCoreDbContext.MaintenanceLog
                                        .Where(x => x.LogType == MaintenanceLogType.Gym)
                                        .OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefault()
                                        .Id;
                            }
                            Gym gym = await _efCoreDbContext.Gym
                                .Include(
                                    x => x.MaintenaceLog.OrderByDescending(y => y.Id)
                                    .Where(p => p.Id <= lastId)
                                    .Take(5)
                                )
                                .AsNoTracking()
                                .FirstOrDefaultAsync(); //Since there's only 1 Gym
                            return gym.MaintenaceLog;
                            break;
                        case MaintenanceLogType.SwimmingPoolIndoor:
                            if (lastId == 0)
                            {
                                lastId = _efCoreDbContext.MaintenanceLog
                                        .Where(x => x.LogType == MaintenanceLogType.SwimmingPoolIndoor)
                                        .OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefault()
                                        .Id;
                            }


                            SwimmingPool pool = await _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Indoor)
                                .Include(
                                    x => x.MaintenaceLog.OrderByDescending(y => y.Id)
                                    .Where(p => p.Id <= lastId)
                                    .Take(5)
                                )
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            return pool.MaintenaceLog;
                            break;
                        case MaintenanceLogType.SwimmingPoolOutdoor:
                            if (lastId == 0)
                            {
                                lastId = _efCoreDbContext.MaintenanceLog
                                        .Where(x => x.LogType == MaintenanceLogType.SwimmingPoolOutdoor)
                                        .OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefault()
                                        .Id;
                            }


                            SwimmingPool poolOutdoor = await _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Outdoor)
                                .Include(
                                    x => x.MaintenaceLog.OrderByDescending(y => y.Id)
                                    .Where(p => p.Id <= lastId)
                                    .Take(5)
                                )
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            return poolOutdoor.MaintenaceLog;
                            break;
                        case MaintenanceLogType.CommonAmenitiesMen:
                            if (lastId == 0)
                            {
                                lastId = _efCoreDbContext.MaintenanceLog
                                        .Where(x => x.LogType == MaintenanceLogType.CommonAmenitiesMen)
                                        .OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefault()
                                        .Id;
                            }


                            CommonAmenities amenitiesMen = await _efCoreDbContext.CommonAmenities
                                .Where(a => a.AmenityType == AmenityType.CommonAmenitiesMen)
                                .Include(
                                    x => x.MaintenaceLog.OrderByDescending(y => y.Id)
                                    .Where(p => p.Id <= lastId)
                                    .Take(5)
                                )
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            return amenitiesMen.MaintenaceLog;
                            break;
                        case MaintenanceLogType.CommonAmenitiesWomen:
                            if (lastId == 0)
                            {
                                lastId = _efCoreDbContext.MaintenanceLog
                                        .Where(x => x.LogType == MaintenanceLogType.CommonAmenitiesWomen)
                                        .OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefault()
                                        .Id;
                            }


                            CommonAmenities amenitiesWomen = await _efCoreDbContext.CommonAmenities
                                .Where(a => a.AmenityType == AmenityType.CommonAmenitiesWomen)
                                .Include(
                                    x => x.MaintenaceLog.OrderByDescending(y => y.Id)
                                    .Where(p => p.Id <= lastId)
                                    .Take(5)
                                )
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
                            return amenitiesWomen.MaintenaceLog;
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

        public async Task<bool> PostMaintenanceLogAsync(MaintenanceLogType type, MaintenanceLog log)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    switch (type)
                    {
                        case MaintenanceLogType.Gym:
                            Gym retrivedGym = await _efCoreDbContext.Gym
                                .Include(x => x.MaintenaceLog)
                                .FirstOrDefaultAsync();
                            if (retrivedGym == null) return false;

                            retrivedGym.MaintenaceLog.Add(log);
                            await _efCoreDbContext.SaveChangesAsync();

                            return true;
                            break;
                        case MaintenanceLogType.SwimmingPoolIndoor:
                            SwimmingPool retrievedPool = await _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Indoor)
                                .Include(x => x.MaintenaceLog)
                                .FirstOrDefaultAsync();

                            retrievedPool.MaintenaceLog.Add(log);
                            await _efCoreDbContext.SaveChangesAsync();

                            return true;

                            break;
                        case MaintenanceLogType.SwimmingPoolOutdoor:
                            SwimmingPool retrievedPoolOutdoor = await _efCoreDbContext.SwimmingPool
                                .Where(a => a.PoolType == SwimmingPoolType.Outdoor)
                                .Include(x => x.MaintenaceLog)
                                .FirstOrDefaultAsync();

                            retrievedPoolOutdoor.MaintenaceLog.Add(log);
                            await _efCoreDbContext.SaveChangesAsync();

                            return true;
                            break;
                        case MaintenanceLogType.CommonAmenitiesMen:
                            CommonAmenities retrievedAmenitiesMen = await _efCoreDbContext.CommonAmenities
                                .Where(a => a.AmenityType == AmenityType.CommonAmenitiesMen)
                                .Include(x => x.MaintenaceLog)
                                .FirstOrDefaultAsync();

                            retrievedAmenitiesMen.MaintenaceLog.Add(log);
                            await _efCoreDbContext.SaveChangesAsync();
                            
                            return true;
                            break;
                        case MaintenanceLogType.CommonAmenitiesWomen:
                            CommonAmenities retrievedAmenitiesWomen = await _efCoreDbContext.CommonAmenities
                                .Where(a => a.AmenityType == AmenityType.CommonAmenitiesWomen)
                                .Include(x => x.MaintenaceLog)
                                .FirstOrDefaultAsync();

                            retrievedAmenitiesWomen.MaintenaceLog.Add(log);
                            await _efCoreDbContext.SaveChangesAsync();

                            return true;
                            break;
                        default:
                            break;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }


        public async Task<bool> EditMaintenanceLogAsync(MaintenanceLog log)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    MaintenanceLog retrievedLog = await _efCoreDbContext.MaintenanceLog.FindAsync(log.Id);
                    _efCoreDbContext.Entry(retrievedLog).CurrentValues.SetValues(log);
                    await _efCoreDbContext.SaveChangesAsync();
                    return true;
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
