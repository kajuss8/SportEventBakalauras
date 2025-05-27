using System.Net;
using Microsoft.EntityFrameworkCore;
using SportEventsApp.Data;
using SportEventsApp.Interfaces;
using SportEventsApp.Models;

namespace SportEventsApp.Repositories
{
    public class SportEventRepository : ISportEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SportEventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SportEvent>> GetAllEvents()
        {
            return await _dbContext.SportEvents.ToListAsync();
        }

        public async Task<List<SportEvent>> GetAllActiveSportEvents()
        {
            return await _dbContext.SportEvents
                .Where(se => se.IsActive)
                .ToListAsync();
        }

        public async Task<List<SportEvent>> GetAllNotActiveSportEvents()
        {
            return await _dbContext.SportEvents
                .Where(se => !se.IsActive)
                .ToListAsync();
        }

        public async Task<SportEvent> GetSportEventById(int id)
        {
            return await _dbContext.SportEvents.Where(se => se.Id == id && se.IsActive).FirstOrDefaultAsync();
        }

        public async Task UpdateExpiredEventsAsync()
        {
            var now = DateTime.Now;

            var expiredEvents = _dbContext.SportEvents
                .Where(e => e.IsActive && e.Date <= DateOnly.FromDateTime(now) &&
                e.BeginningTime < TimeOnly.FromDateTime(now))
                .ToList();

            foreach (var eventItem in expiredEvents)
            {
                eventItem.IsActive = false;
            }

            if (expiredEvents.Any())
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateSportEvent(SportEvent sportEvent)
        {
            _dbContext.SportEvents.Update(sportEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SportEvent>> GetUserCreatedEvents(string appUserId)
        {
            return await _dbContext.SportEvents
                .Where(e => e.CreatorId == Guid.Parse(appUserId) && e.IsActive)
                .ToListAsync();
        }

        public async Task DeleteSportEvent(int id, string comment)
        {
            var sportEvent = await _dbContext.SportEvents.FindAsync(id);
            if (sportEvent != null)
            {
                sportEvent.IsActive = false;
                sportEvent.DeleteTime = DateTime.Now;
                sportEvent.DeleteComment = comment;
                _dbContext.SportEvents.Update(sportEvent);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Sport event with ID {id} not found.");
            }


        }
    }
}
