using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public SocietyRoleType Role { get; set; }

    }
}