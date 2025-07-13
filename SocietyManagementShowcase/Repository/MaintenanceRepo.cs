using Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using Common.Models;

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
                        case MaintenanceLogType.CommonAmenitiesMen:
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
                        case MaintenanceLogType.CommonAmenitiesMen:
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
