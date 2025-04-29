using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IUserRepo
    {
        Task<bool> VerifyUser(User user);
    }
}