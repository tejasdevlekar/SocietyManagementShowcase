using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Elevator
    {
        public int Id { get; set; }
        public Wing Wing { get; set; }
        public ElevatorType Type { get; set; }
        public StatusHealth Health { get; set; }
    }

    public enum ElevatorType
    {
        PassengerElevator1 = 0,
        PassengerElevator2,
        ServiceElevator
    }
}