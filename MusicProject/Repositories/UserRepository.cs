using MusicProject.Models;
using MusicProject.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
        }
    }

    public void DeleteUser(int id)
    {
        var userToDelete = _users.FirstOrDefault(u => u.Id == id);
        if (userToDelete != null)
        {
            _users.Remove(userToDelete);
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users.ToList(); // Возвращаем копию списка пользователей
    }

}
