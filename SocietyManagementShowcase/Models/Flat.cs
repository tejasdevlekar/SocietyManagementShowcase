using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string FlatNo { get; set; }
        public string Wing { get; set; }
        public List<Person> Residents { get; set; }
        public Person Owner { get; set; }
        public float AreaSqFt { get; set; }
        public float MaintenanceCharge { get; set; }
    }
}