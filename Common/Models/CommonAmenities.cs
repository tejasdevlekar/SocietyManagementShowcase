using Common.Common;

namespace Common.Models
{
    public class CommonAmenities
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> MaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
        public CommonAmenitiesType Type { get; set; }
        public AmenityType AmenityType { get; set; }
    }

    public enum CommonAmenitiesType
    {
        Men = 0,
        Women
    }
}