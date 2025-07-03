using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class WaterTank
    {
        public int Id { get; set; }
        public WaterTankType Type { get; set; }
        public int Capacity { get; set; }
        public int WaterLevel { get; set; }
        public StatusHealth Health { get; set; }
        public List<MaintenanceLog> WaterTankMaintenaceLog { get; set; }
        public int  WingId { get; set; }
        public Wing  Wing { get; set; }
        public DateOnly LastMaintenanceCheck { get; set; }

    }

    public enum WaterTankType
    {
        Kitchen = 0,
        Bathroom,
        Flush
    }
}