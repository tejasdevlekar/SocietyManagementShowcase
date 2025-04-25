using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string FlatNo { get; set; }
        public List<Person> Residents { get; set; }
        public Person Owner { get; set; }

    }
}