using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;
using SocietyManagementShowcase.Models;

namespace SocietyManagementShowcase.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;

        public UserRepo(EfCoreDbContext efCoreDbContext)
        {
            _efCoreDbContext = efCoreDbContext;
        }
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
                using (_efCoreDbContext)
                {
                    User retrievedUser = _efCoreDbContext.Users.Where(x => x.Username == user.Username).FirstOrDefault();
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

        public async Task<bool> AddUserAsync(User user)
        {
            using(_efCoreDbContext)
            {
                _efCoreDbContext.Users.Add(user);
                _efCoreDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = new List<User>();

            using (_efCoreDbContext)
            {
                users = await _efCoreDbContext.Users.ToListAsync();
            }
            return users;
        }

        public async Task<User> FetchUserAsync(int id)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    User retrievedUser = await _efCoreDbContext.Users.FindAsync(id);
                    return retrievedUser;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
        public async Task<bool> EditUserAsync(int id,  User user)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    User retrievedUser = await _efCoreDbContext.Users.FindAsync(id);
                    if (retrievedUser != null)
                    {
                        _efCoreDbContext.Entry(retrievedUser).CurrentValues.SetValues(user);
                        await _efCoreDbContext.SaveChangesAsync();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
