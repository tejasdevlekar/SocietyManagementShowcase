using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> GymMaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
    }
}