using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.IRepository
{
    public interface IUserRepo
    {
        Task<bool> VerifyUser(User user);
        Task<bool> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> FetchUserAsync(int id);
        Task<bool> EditUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

    }
}