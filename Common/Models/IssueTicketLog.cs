namespace SocietyManagementShowcase.Models
{
    public class IssueTicketLog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Person CreatedBy { get; set; }
        public TicketStatus Status { get; set; }
        public string Remarks { get; set; }
    }

    public enum TicketStatus
    {
        Created = 0,
        Assigned,
        InProgress,
        Resolved
    }
}