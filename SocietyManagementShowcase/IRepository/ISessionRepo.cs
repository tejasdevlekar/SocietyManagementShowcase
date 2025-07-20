using Common.Common;

namespace SocietyManagementShowcase.IRepository
{
    public interface ISessionRepo
    {
        Task AddSession(MySessionModel sessionModel);
        Task<MySessionModel> GetSession(string sessionId);
    }
}