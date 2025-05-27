namespace SportEventsApp.Models
{
    public class ReportUser
    {
        public int Id { get; set; }
        public Guid ReportingUserId { get; set; }
        public Guid ReportedUserId { get; set; }
        public string? Comment { get; set; }
        public string? Category { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
