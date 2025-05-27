using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportEventsApp.Models;

namespace SportEventsApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<SportEvent> SportEvents { get; set; }
        public DbSet<SportEventSportLevel> SportEventSportLevels { get; set; }
        public DbSet<SportLevel> SportsLevels { get; set; }
        public DbSet<ApplicationUserSportEvent> UserSportEvents { get; set; }
        public DbSet<ApplicationUserSportLevel> UserSportLevels { get; set; }
        public DbSet<FriendList> FriendList { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<ReportUser> ReportUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportEventSportLevel>()
            .HasKey(e => new { e.SportEventId, e.SportLevelId });
            modelBuilder.Entity<ApplicationUserSportEvent>()
            .HasKey(e => new { e.UserId, e.SportEventId });
            modelBuilder.Entity<ApplicationUserSportLevel>()
            .HasKey(e => new { e.UserId, e.SportLevelId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
