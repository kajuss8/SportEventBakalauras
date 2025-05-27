using Microsoft.EntityFrameworkCore;
using SportEventsApp.Data;
using SportEventsApp.Interfaces;
using SportEventsApp.Models;

namespace SportEventsApp.Repositories
{
    public class UserSportEventRepository : IUserSportEventRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserSportEventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserSportEvent(ApplicationUserSportEvent user)
        {
            await _dbContext.UserSportEvents.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesUserAndEventExist(Guid userId, int eventId)
        {
            return await _dbContext.UserSportEvents
                .AnyAsync(x => x.UserId == userId && x.SportEventId == eventId && x.DeclineDate == null);
        }

        public async Task<bool> DidUserCreatedEvent(Guid userId, int eventId)
        {
            return await _dbContext.UserSportEvents
                .AnyAsync(x => x.UserId == userId && x.SportEventId == eventId && x.DeclineDate == null);
        }

        public async Task<List<SportEvent>> GetUserJoinedEvents(string appUserId)
        {
            return await _dbContext.UserSportEvents
                    .Where(ue => ue.UserId == Guid.Parse(appUserId) && ue.SportEvent.IsActive && ue.SportEvent.CreatorId != Guid.Parse(appUserId) && ue.DeclineDate == null)
                    .Select(ue => ue.SportEvent)
                    .ToListAsync();
        }

        public async Task<List<string>> GetUserIdsByEventId(int eventId)
        {
            return await _dbContext.UserSportEvents
                .Where(ue => ue.SportEventId == eventId)
                .Select(ue => ue.UserId.ToString())
                .ToListAsync();
        }

        public async Task<bool> IsUserInEvent(string appUserId, int eventId)
        {
            return await _dbContext.UserSportEvents
                .AnyAsync(ue => ue.UserId.ToString() == appUserId && ue.SportEventId == eventId);
        }

        public async Task<ApplicationUserSportEvent> GetUserSportEventByUserIdAndEventId(string appUserId, int eventId)
        {
            return await _dbContext.UserSportEvents
                .FirstOrDefaultAsync(ue => ue.UserId.ToString() == appUserId && ue.SportEventId == eventId);
        }

        public async Task DeleteUserSportEvent(ApplicationUserSportEvent userSportEvent)
        {   
            _dbContext.UserSportEvents.Remove(userSportEvent);
            await _dbContext.SaveChangesAsync();
            userSportEvent.DeclineDate = DateTime.Now;
            userSportEvent.Decliner = Guid.Parse(userSportEvent.UserId.ToString());
            userSportEvent.UserId = Guid.NewGuid();
            await CreateUserSportEvent(userSportEvent);
            await _dbContext.SaveChangesAsync();

        }
    }
}
