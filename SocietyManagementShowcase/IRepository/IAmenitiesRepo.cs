using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IAmenitiesRepo
    {
        Task<Gym> GetGymInfoAsync(int id);
    }
}