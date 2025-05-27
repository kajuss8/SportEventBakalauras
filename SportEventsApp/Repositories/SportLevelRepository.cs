

using Microsoft.EntityFrameworkCore;
using SportEventsApp.Data;
using SportEventsApp.enums;
using SportEventsApp.Interfaces;
using SportEventsApp.Models;

namespace SportEventsApp.Repositories
{
    public class SportLevelRepository : ISportLevelRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public SportLevelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SportLevel>> GetSportLevelsByUserId(Guid userId)
        {
            return await _dbContext.UserSportLevels
                .Where(ausl => ausl.UserId == userId)
                .Select(ausl => ausl.SportLevel)
                .ToListAsync();
        }

        public async Task CreateSportlevel(SportLevel sportLevel, Guid userId)
        {
            try
            {
                await _dbContext.SportsLevels.AddAsync(sportLevel);
                await _dbContext.SaveChangesAsync();

                var userSportLevel = new ApplicationUserSportLevel
                {
                    UserId = userId,
                    SportLevelId = sportLevel.Id
                };

                await _dbContext.UserSportLevels.AddAsync(userSportLevel);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating sport level: {ex.Message}");
            }
        }

        public async Task DeleteSportLevel(int sportLevelId, Guid userId)
        {
            var userSportLevel = await _dbContext.UserSportLevels
                .FirstOrDefaultAsync(ausl => ausl.SportLevelId == sportLevelId && ausl.UserId == userId);

            if (userSportLevel != null)
            {
                _dbContext.UserSportLevels.Remove(userSportLevel);
                await _dbContext.SaveChangesAsync();
            }
        }

        

        public List<SportLevel> GetSportLevelsByEventId(int id)
        {
            return _dbContext.SportEventSportLevels
                .Where(s => s.SportEventId == id)
                .Select(s => s.SportLevel)
                .ToList();
        }

        public Sports GetSportById(int id)
        {
            return _dbContext.SportEventSportLevels
                .Where(s => s.SportEventId == id)
                .Select(s => s.SportLevel.Sport).FirstOrDefault();

        }

        public bool IsUserAndEventlevelEqual(Guid userId, List<SportLevel> sportLevels)
        {
            var userSportLevels = _dbContext.UserSportLevels
                .Where(ausl => ausl.UserId == userId)
                .Select(ausl => ausl.SportLevel)
                .ToList();
            foreach (var sportLevel in sportLevels)
            {
                if (userSportLevels.Any(u => u.Sport == sportLevel.Sport && u.Level == sportLevel.Level))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<SportLevels> GetUserSportLevel(string userId, int eventId)
        {
            var userSportLevel = await _dbContext.UserSportLevels
                .Where(sl => sl.UserId == Guid.Parse(userId) && sl.SportLevel.Sport == GetSportById(eventId)).
                Select(sl => sl.SportLevel.Level)
                .FirstOrDefaultAsync();

            return userSportLevel;
        }

        public string GetSportLevelDisplayName(SportLevels sportLevel)
        {
            return sportLevel switch
            {
                SportLevels.Beginner => "Beginner",
                SportLevels.LowerIntermediate => "Lower intermediate",
                SportLevels.Intermediate => "Intermediate",
                SportLevels.UpperIntermediate => "Upper intermediate",
                SportLevels.Expert => "Expert",
                _ => sportLevel.ToString()
            };
        }
    }
}
