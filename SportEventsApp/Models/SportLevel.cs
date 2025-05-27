using SportEventsApp.enums;

namespace SportEventsApp.Models
{
    public class SportLevel
    {
        public int Id { get; set; }
        public Sports Sport { get; set; }
        public SportLevels Level { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
