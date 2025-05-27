using Microsoft.AspNetCore.Identity;
using SportEventsApp.enums;

namespace SportEventsApp.Data
{

    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? City { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime LastLoggedTime { get; set; }
        public DateTime? BlockDate { get; set; }
        public string? BlockComment { get; set; }
        public Genders? Gender { get; set; }
    }

}
