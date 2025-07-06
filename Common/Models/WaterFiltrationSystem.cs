using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class WaterFiltrationSystem
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> WaterFiltrationSystemMaintenaceLog { get; set; }
        public DateOnly LastMaintenanceCheck { get; set; }
    }
}