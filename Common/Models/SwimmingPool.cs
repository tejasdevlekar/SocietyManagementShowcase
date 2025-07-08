using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class SwimmingPool
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> SwimmingPoolMaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
        public SwimmingPoolType PoolType { get; set; }
    }

    public enum SwimmingPoolType
    {
        Indoor = 0,
        Outdoor
    }
}