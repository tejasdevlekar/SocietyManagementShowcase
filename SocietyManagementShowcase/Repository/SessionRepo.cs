using Common.Common;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using System.Threading.Tasks;

namespace SocietyManagementShowcase.Repository
{
    public class SessionRepo : ISessionRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<SessionRepo> _logger;

        public SessionRepo(EfCoreDbContext efCoreDbContext, ILogger<SessionRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task AddSession(MySessionModel sessionModel)
        {
            using (_efCoreDbContext)
            {
                await _efCoreDbContext.MySessionModel.AddAsync(sessionModel);
                await _efCoreDbContext.SaveChangesAsync();
            }
        }

        public async Task<MySessionModel> GetSession(string sessionId)
        {
            // return _sessionStorage.FirstOrDefault(s => s.Id == sessionId);
            using (_efCoreDbContext)
            {
                return await _efCoreDbContext.MySessionModel.FirstOrDefaultAsync(s => s.Id == sessionId);
            }
        }


    }
}
