using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Gym
    {
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> SwimmingPoolMaintenaceLog { get; set; }
        public DateOnly LastMaintenanceCheck { get; set; }
    }
}