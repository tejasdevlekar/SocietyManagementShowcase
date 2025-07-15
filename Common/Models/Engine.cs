using Common.Common;

namespace Common.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public int FuelLevel { get; set; }
        public int OilLevel { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> EngineMaintenaceLog { get; set; }
        public DateOnly LastMaintenanceCheck { get; set; }
    }
}