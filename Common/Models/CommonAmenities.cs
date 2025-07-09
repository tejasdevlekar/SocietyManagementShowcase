using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class CommonAmenities
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> CommonAmenitiesMaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
        public CommonAmenitiesType Type { get; set; }
    }

    public enum CommonAmenitiesType
    {
        Men = 0,
        Women
    }
}