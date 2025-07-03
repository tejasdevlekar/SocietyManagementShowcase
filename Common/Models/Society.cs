using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Society
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wing> Wing { get; set; }
        public int NoOfWings { get; set; }
        public Person Manager { get; set; }
        public List<Person> SecurityStaff { get; set; }
        public List<Person> HouseKeepingStaff { get; set; }
        public FireFightingSystem FireSystem { get; set; }
        public WaterFiltrationSystem WaterFilter { get; set; }
        public SwimmingPool OutdoorSwimmingPool { get; set; }
        public SwimmingPool IndoorSwimmingPool { get; set; }
        public Gym IndoorGym { get; set; }
        public CommonAmenities CommonAmenitiesMen { get; set; }
        public CommonAmenities CommonAmenitiesWomen { get; set; }
        public StatusHealth Health { get; set; }
        public double TotalFlatAreaSociety { get; set; }
        public double TotalMaintenanceChargeSociety { get; set; }
        public List<VisitorLog> LogOfVisitors { get; set; }
        public List<IssueTicketLog> IssueTicketSociety { get; set; }

    }
}
