using SportEventsApp.Models;

namespace SportEventsApp.Interfaces
{
    public interface IFriendListRepository
    {
        Task<bool> RemoveFriendAsync(Guid userId, Guid friendId);
        Task<List<FriendList>> GetFriends(Guid userId);
    }
}
