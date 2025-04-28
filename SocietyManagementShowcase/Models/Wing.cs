namespace SocietyManagementShowcase.Models
{
    public class Wing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person SubManager { get; set; }
        public List<Flat> FlatList { get; set; }
        public Elevator PassengerElevator1 { get; set; }
        public Elevator PassengerElevator2 { get; set; }
        public Elevator ServiceElevator { get; set; }
        public WaterTank Kitchen { get; set; }
        public WaterTank Bathroom { get; set; }
        public WaterTank Flush { get; set; }
        public List<string> NoticeBoard { get; set; }
        public double ElectricMeterReading { get; set; }
        public double ElectricMeterBill { get; set; }
        public ElectricityGenerator BackupGenerator { get; set; }
        public double TotalFlatAreaWing { get; set; }
        public double TotalMaintenanceChargeWing { get; set; }
        public List<VisitorLog> LogOfVisitors { get; set; }
        public List<IssueTicketLog> IssueTicketWing { get; set; }

    }
}