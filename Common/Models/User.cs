namespace Common.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public bool isDeleted { get; set; }
        public UserRoleType RoleType { get; set; }
    }

    public enum UserRoleType
    {
        SuperAdmin = 0,
        Admin,
        Manager,
        Staff,
        Member
    }

}
