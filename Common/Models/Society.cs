using Common.Common;

namespace Common.Models
{
    public class Society
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wing> Wing { get; set; }
        public int NoOfWings { get; set; }
        public List<Person> Staff { get; set; }
        public FireFightingSystem FireSystem { get; set; }
        public WaterFiltrationSystem WaterFilter { get; set; }
        public ICollection<SwimmingPool> SwimmingPools { get; set; }        
        public Gym IndoorGym { get; set; }
        public ICollection<CommonAmenities> CommonAmenities { get; set; }        
        public StatusHealth Health { get; set; }
        public double TotalFlatAreaSociety { get; set; }
        public double TotalMaintenanceChargeSociety { get; set; }
        public List<VisitorLog> LogOfVisitors { get; set; }
        public List<IssueTicketLog> IssueTicketSociety { get; set; }

    }
}
