using Microsoft.EntityFrameworkCore;
using SportEventsApp.Data;
using SportEventsApp.Interfaces;

namespace SportEventsApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _dbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
    }
}
