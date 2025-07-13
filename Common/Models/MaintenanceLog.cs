namespace Common.Models
{
    public class MaintenanceLog
    {
        public int Id { get; set; }
        public string MaintenaceDoneByName { get; set; }
        public string MaintenaceCheckedByName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public MaintenanceLogType LogType { get; set; }
    }

    public enum MaintenanceLogType
    {
        Gym = 0,
        SwimmingPoolIndoor,
        SwimmingPoolOutdoor,
        CommonAmenitiesMen,
        CommonAmenitiesWomen
    }
}