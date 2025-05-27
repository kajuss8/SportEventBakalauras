namespace SportEventsApp.Models
{
    public class SportEvent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Location { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly BeginningTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public double? Price { get; set; }
        public string? Comment { get; set; }
        public bool IsPrivateEvent { get; set; } = false;
        public string? PrivateEventCode { get; set; }
        public int CurrentPlayersNumber { get; set; }
        public int TotalPlayers { get; set; }
        public bool IsConfirmation { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime? DeleteTime { get; set; }
        public string? DeleteComment { get; set; }
        public DateTime CreatedEventDate { get; set; } = DateTime.Now;
        public Guid CreatorId { get; set; }
        public bool IsMale { get; set; } = false;
        public bool IsFemale { get; set; } = false;
    }
}
