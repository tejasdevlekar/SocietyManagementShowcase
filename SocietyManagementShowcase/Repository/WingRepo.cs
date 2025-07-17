using Common.Models;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;

namespace SocietyManagementShowcase.Repository
{
    public class WingRepo : IWingRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<WingRepo> _logger;

        public WingRepo(EfCoreDbContext efCoreDbContext, ILogger<WingRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<List<Wing>> GetWingIdAndNameAsync()
        {
            try
            {
                using (_efCoreDbContext)
                {
                    List<Wing> wings = await _efCoreDbContext.Wing
                        .Select(x => new Wing
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .AsNoTracking()
                        .ToListAsync();
                    return wings;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new List<Wing>();
            }
        }



    }
}
