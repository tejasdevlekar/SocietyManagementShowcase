using Common.Common;

namespace Common.Models
{
    public class WaterFiltrationSystem
    {
        public int Id { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> WaterFiltrationSystemMaintenaceLog { get; set; }
        public DateTime LastMaintenanceCheck { get; set; }
    }
}