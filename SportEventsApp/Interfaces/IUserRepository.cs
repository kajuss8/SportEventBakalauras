using SportEventsApp.Data;

namespace SportEventsApp.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(string userId);
    }
}
