using SportEventsApp.enums;
using SportEventsApp.Models;

namespace SportEventsApp.Interfaces
{
    public interface ISportLevelRepository
    {
        Task<List<SportLevel>> GetSportLevelsByUserId(Guid userId);
        Task CreateSportlevel(SportLevel sportLevel, Guid userId);
        Task DeleteSportLevel(int sportLevelId, Guid userId);
        string GetSportLevelDisplayName(SportLevels sportLevel);
        List<SportLevel> GetSportLevelsByEventId(int id);
        Sports GetSportById(int id);
        bool IsUserAndEventlevelEqual(Guid userId, List<SportLevel> sportLevels);
        Task<SportLevels> GetUserSportLevel(string userId, int eventId);

    }
}
