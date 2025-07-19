using Common.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IPersonRepo
    {
        Task<List<Person>> GetAllPersonsAsync(int firstId);
    }
}