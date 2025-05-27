using SportEventsApp.enums;
using System.ComponentModel.DataAnnotations;

namespace SportEventsApp.Models.dataService
{
    public class CreateEventData
    {
        public Sports? Sports { get; set; }
        public string? EventName { get; set; }
        public string? City { get; set; }
        public string? Location { get; set; }
        public double? Price { get; set; }
        public bool IsPrivate { get; set; } = false;
        public string? EventDescription { get; set; }
        public List<int> EventSelectedLevels { get; set; } = new List<int>();
    }
}
