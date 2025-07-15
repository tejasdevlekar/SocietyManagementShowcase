using Common.Common;

namespace Common.Models
{
    public class FireFightingSystem
    {
        public int Id { get; set; }
        public WaterTank Fire { get; set; }
        public Engine FireSystemEngine { get; set; }

        public StatusHealth Health { get; set; }
    }
}