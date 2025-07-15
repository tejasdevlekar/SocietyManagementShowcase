using Common.Models;

namespace Common
{
    public class LoginResponse
    {
        public bool status { get; set; }
        public User User { get; set; }
    }
}
