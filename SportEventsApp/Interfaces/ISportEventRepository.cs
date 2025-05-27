using Microsoft.EntityFrameworkCore;
using SportEventsApp.Models;

namespace SportEventsApp.Interfaces
{
    public interface ISportEventRepository
    {
        Task<List<SportEvent>> GetAllEvents();
        Task<List<SportEvent>> GetAllActiveSportEvents();
        Task<List<SportEvent>> GetAllNotActiveSportEvents();
        Task UpdateExpiredEventsAsync();
        Task<List<SportEvent>> GetUserCreatedEvents(string appUserId);
        Task UpdateSportEvent(SportEvent sportEvent);
        Task<SportEvent> GetSportEventById(int id);
        Task DeleteSportEvent(int id, string comment);
    }
}
