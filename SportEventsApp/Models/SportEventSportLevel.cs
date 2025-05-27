namespace SportEventsApp.Models
{
    public class SportEventSportLevel
    {
        public int SportEventId { get; set; }
        public int SportLevelId { get; set; }
        public SportEvent? SportEvent { get; set; }
        public SportLevel? SportLevel { get; set; }
    }
}
