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

        public async Task<Gym> GetGymInfoAsync(int id)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    Gym gym = await _efCoreDbContext.Gym.FindAsync(id);
                    return gym;
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
