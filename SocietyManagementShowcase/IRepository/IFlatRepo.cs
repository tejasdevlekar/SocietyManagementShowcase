using Common.Models;
using System.Threading.Tasks;

namespace SocietyManagementShowcase.IRepository
{
    public interface IFlatRepo
    {
        Task<Flat> GetFlatAsync(int id);
        Task<dynamic> GetAllFlatsAsync(int lastId);
        Task<bool> AddFlatAsync(Flat flat);
    }
}