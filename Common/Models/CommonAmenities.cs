using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class CommonAmenities
    {
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> CommonAmenitiesMaintenaceLog { get; set; }
        public DateOnly LastMaintenanceCheck { get; set; }
    }
}