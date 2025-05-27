using SportEventsApp.Data;

namespace SportEventsApp.Models
{
    public class ApplicationUserSportLevel
    {
        public Guid UserId { get; set; }
        public int SportLevelId { get; set; }
        public ApplicationUser? User { get; set; }
        public SportLevel? SportLevel { get; set; }
    }
}
