using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.Repository
{
    public class UserRepo : IUserRepo
    {
        //public async Task<bool> VerifyUser(User user)
        //{
        //    try
        //    {
        //        using EfCoreDbContext context = new EfCoreDbContext();

        //        User? retrievedUser = context.Users.FromSqlInterpolated($@"
        //            EXEC spVerifyUser 
        //                @Username = {user.Username}, 
        //                @Password = {user.Password} 
        //        ").AsNoTracking().AsEnumerable().FirstOrDefault();

        //        if (retrievedUser != null)
        //        {
        //            if (user.Username == retrievedUser.Username && user.Password == retrievedUser.Password) return true;
        //            else return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return false;
        //}

        public async Task<bool> VerifyUser(User user)
        {
            try
            {
                using (EfCoreDbContext context = new EfCoreDbContext())
                {
                    User retrievedUser = context.Users.Where(x => x.Username == user.Username).FirstOrDefault();
                    if (retrievedUser != null)
                    {
                        if (user.Username == retrievedUser.Username && user.Password == retrievedUser.Password) return true;
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
