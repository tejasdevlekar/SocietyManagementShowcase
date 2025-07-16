using Common.Models;
using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Repository
{
    public class WingRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<WingRepo> _logger;

        public WingRepo(EfCoreDbContext efCoreDbContext, ILogger<WingRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<List<Wing>> GetWingIdAndName()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new List<Wing>;
            }
        }



    }
}
