using Common.Common;

namespace Common.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string FlatNo { get; set; }
        public SocietyRoleType Role { get; set; }

    }
}