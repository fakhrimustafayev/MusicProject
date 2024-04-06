using Microsoft.AspNetCore.Identity;
using MusicProject.Data;
using MusicProject.Models;
using MusicProject.Services.Users;
using MusicProject.ViewModels;

public class UserRepository : IUserRepository
{
    private readonly MusicProjectContext _musicProjectContext;

    private readonly UserManager<User> _userManager;

    public UserRepository(MusicProjectContext musicProjectContext, UserManager<User> userManager)
    {
        _musicProjectContext = musicProjectContext;
        _userManager = userManager;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _musicProjectContext.User.FindAsync(id);
    }

    public async Task AddUserAsync(RegisterViewModel user)
    {
        //var user = new RegisterViewModel
        await _userManager.CreateAsync(new User() { Email=user.Email }, user.Password);

    }

    public async Task UpdateUserAsync(User user)
    {
        var existingUser =  await _musicProjectContext.User.FindAsync(user.Id);
        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        var userToDelete =  await _musicProjectContext.User.FindAsync(id);
        if (userToDelete != null)
        {
            _musicProjectContext.User.Remove(userToDelete);
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _musicProjectContext.User.ToList(); // Возвращаем копию списка пользователей
    }

}
