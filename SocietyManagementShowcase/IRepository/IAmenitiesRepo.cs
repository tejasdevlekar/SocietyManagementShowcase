using Common;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IAmenitiesRepo
    {
        Task<Gym> GetAmenityInfoAsync(AmenityType type);
    }
}