namespace SportEventsApp.Models
{
    public class FriendList
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsAccepted { get; set; } = false;
    }
}
