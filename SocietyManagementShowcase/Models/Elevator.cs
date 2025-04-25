using SocietyManagementShowcase.Common;

namespace SocietyManagementShowcase.Models
{
    public class Elevator
    {
        public int Id { get; set; }
        public string WingName { get; set; }
        public ElevatorType Type { get; set; }
        public StatusHealth Health { get; set; }
    }

    public enum ElevatorType
    {
        PassengerElevator = 0,
        ServiceElevator
    }
}