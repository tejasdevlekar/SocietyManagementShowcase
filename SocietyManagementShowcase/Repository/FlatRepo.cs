using Common.Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;

namespace SocietyManagementShowcase.Repository
{
    public class FlatRepo : IFlatRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<FlatRepo> _logger;

        public FlatRepo(EfCoreDbContext efCoreDbContext, ILogger<FlatRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<Flat> GetFlatAsync(int id)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    Flat flat = await _efCoreDbContext.Flat
                         .Where(x => x.Id == id)
                         .AsNoTracking()
                        .FirstOrDefaultAsync();
                    return flat;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting flat");
                return null;
            }
        }

        public async Task<dynamic> GetAllFlatsAsync(int lastId)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    if(lastId <= 0){
                        lastId = int.MinValue;
                    }
                    var flats = (from flat in _efCoreDbContext.Flat
                                join wing in _efCoreDbContext.Wing on flat.WingId equals wing.Id
                                where flat.Id >= lastId
                                 select new
                                {   
                                    Id = flat.Id,
                                    FlatNo = flat.FlatNo,
                                    AreaSqFt = flat.AreaSqFt,
                                    MaintenanceCharge = flat.MaintenanceCharge,
                                    WingId = flat.WingId,
                                    WingName = wing.Name
                                }).Take(5).ToList();

                    return flats;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all flats");
                return null;
            }
        }
        public async Task<bool> AddFlatAsync(Flat flat)
        {
            try
            {
                await _efCoreDbContext.Flat.AddAsync(flat);
                await _efCoreDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding flat");
                return false;
            }
        }
    }
}
