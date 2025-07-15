using Common.Common;

namespace Common.Models
{
    public class ElectricityGenerator
    {
        public int Id { get; set; }
        public int WingId { get; set; }
        public Wing Wing { get; set; }
        public Engine BackupGeneratorEngine { get; set; }
        public StatusHealth Health { get; set; }

    }
}