using Common.Common;

namespace Common.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> MaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
        public AmenityType AmenityType { get; set; }
    }
}