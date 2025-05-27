using SportEventsApp.Data;

namespace SportEventsApp.Models
{
    public class ApplicationUserSportEvent
    {
        public Guid UserId { get; set; }
        public int SportEventId { get; set; }
        public ApplicationUser? User { get; set; }
        public SportEvent? SportEvent { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime? AcceptDate { get; set; }
        public DateTime? DeclineDate { get; set; }
        public Guid? Decliner { get; set; }
    }
}
