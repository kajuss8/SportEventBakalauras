using SportEventsApp.Data;
using SportEventsApp.Models;

namespace SportEventsApp.Interfaces
{
    public interface IUserSportEventRepository
    {
        Task CreateUserSportEvent(ApplicationUserSportEvent user);
        Task<bool> DoesUserAndEventExist(Guid userId, int eventId);
        Task<List<SportEvent>> GetUserJoinedEvents(string appUserId);
        Task<List<string>> GetUserIdsByEventId(int eventId);
        Task<bool> IsUserInEvent(string appUserId, int eventId);
        Task<ApplicationUserSportEvent> GetUserSportEventByUserIdAndEventId(string appUserId, int eventId);
        Task DeleteUserSportEvent(ApplicationUserSportEvent userSportEvent);
    }
}
