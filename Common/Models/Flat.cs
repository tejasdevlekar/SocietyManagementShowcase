using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public string FlatNo { get; set; }
        public int WingId { get; set; }
        public Wing Wing { get; set; }
        public List<Person> Residents { get; set; }
        public float AreaSqFt { get; set; }
        public float MaintenanceCharge { get; set; }
    }
}