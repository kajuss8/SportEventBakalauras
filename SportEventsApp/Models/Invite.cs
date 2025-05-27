namespace SportEventsApp.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int SportEventId { get; set; }
        public SportEvent? SportEvent { get; set; }
        public Guid UserId { get; set; }
        public Guid InvitedUserId { get; set; }
        public bool Accept { get; set; } = false;
        public bool Decline { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
