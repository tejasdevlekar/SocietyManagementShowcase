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

            ClearExpiredSessions();
        }

        public async Task AddSession(MySessionModel sessionModel)
        {

            await _efCoreDbContext.MySessionModel.AddAsync(sessionModel);
            await _efCoreDbContext.SaveChangesAsync();

        }

        public async Task<MySessionModel> GetSession(string sessionId)
        {
            // return _sessionStorage.FirstOrDefault(s => s.Id == sessionId);

            return await _efCoreDbContext.MySessionModel.FirstOrDefaultAsync(s => s.Id == sessionId);

        }

        public async Task<bool> SetSessionAccess(MySessionModel sessionModel)
        {
            try
            {
                MySessionModel retrievedSession = await (from session in _efCoreDbContext.MySessionModel
                                                         where session.Id == sessionModel.Id
                                                         select session).FirstOrDefaultAsync();
                if (retrievedSession != null)
                {
                    retrievedSession.ExpiresAtTime = sessionModel.ExpiresAtTime;
                    await _efCoreDbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting session model");
            }
            return false;
        }


        private void ClearExpiredSessions()
        {
            try
            {
                var expiredSessions = _efCoreDbContext.MySessionModel
                    .Where(s => s.AbsoluteExpiration < DateTime.UtcNow);
                _efCoreDbContext.MySessionModel.RemoveRange(expiredSessions);
                _efCoreDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing expired sessions");
            }
        }



    }
}
