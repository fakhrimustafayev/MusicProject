using MusicProject.Models;

namespace MusicProject.Services.Users;

public interface IUserRepository
{
    Task<User> GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}
