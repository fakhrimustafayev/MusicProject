using MusicProject.Models;

namespace MusicProject.Repositories;

public interface IUserRepository
{
    User GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
