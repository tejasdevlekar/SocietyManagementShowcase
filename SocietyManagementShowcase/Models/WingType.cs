namespace SocietyManagementShowcase.Models
{
    public class WingType
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
        public string NoticeBoard { get; set; }

    }
}