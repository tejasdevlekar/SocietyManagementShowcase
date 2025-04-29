using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;


namespace SocietyManagementShowcase.Repository
{
    public class UserRepo : IUserRepo
    {
        public async Task<bool> VerifyUser(User user)
        {
            try
            {
                UserLogin.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
