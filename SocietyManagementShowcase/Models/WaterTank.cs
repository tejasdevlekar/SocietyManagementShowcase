using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class WaterTank
    {
        public WaterTankType Type { get; set; }
        public int Capacity { get; set; }
        public int WaterLevel { get; set; }
        public StatusHealth Health { get; set; }
    }

    public enum WaterTankType
    {
        Kitchen = 0,
        Bathroom,
        Flush
    }
}