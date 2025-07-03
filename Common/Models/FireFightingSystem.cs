using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class FireFightingSystem
    {
        public WaterTank Fire { get; set; }
        public Engine FireSystemEngine { get; set; }

        public StatusHealth Health { get; set; }
    }
}