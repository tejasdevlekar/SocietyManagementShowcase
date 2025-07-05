namespace SocietyManagementShowcase.Models
{
    public class Wing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person SubManager { get; set; }
        public List<Flat> FlatList { get; set; }
        public List<Elevator> Elevators { get; set; }
        public List<WaterTank> WaterTanks { get; set; }
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