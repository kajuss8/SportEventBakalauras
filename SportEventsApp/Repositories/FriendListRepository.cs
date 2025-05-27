using Microsoft.EntityFrameworkCore;
using SportEventsApp.Data;
using SportEventsApp.Interfaces;
using SportEventsApp.Models;

namespace SportEventsApp.Repositories
{
    public class FriendListRepository : IFriendListRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FriendListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RemoveFriendAsync(Guid userId, Guid friendId)
        {
            var friendRelation = await _dbContext.FriendList
                .FirstOrDefaultAsync(f =>
                    (f.UserId == userId && f.FriendId == friendId) ||
                    (f.UserId == friendId && f.FriendId == userId));

            if (friendRelation != null)
            {
                _dbContext.FriendList.Remove(friendRelation);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<FriendList>> GetFriends(Guid userId)
        {
            return await _dbContext.FriendList
            .Where(f => (f.UserId == userId || f.FriendId == userId) && f.IsAccepted).ToListAsync();
        }
    }
}
