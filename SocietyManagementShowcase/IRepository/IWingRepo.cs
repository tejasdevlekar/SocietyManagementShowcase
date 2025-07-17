using Common.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IWingRepo
    {
        Task<List<Wing>> GetWingIdAndNameAsync();
    }
}