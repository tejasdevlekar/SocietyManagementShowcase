using Common;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IAmenitiesRepo
    {
        Task<AmenitiesResponse> GetAmenityInfoAsync(AmenityType type);
        Task<bool> UpdateAmenityInfoAsync(AmenityType type, AmenitiesResponse response);
    }
}