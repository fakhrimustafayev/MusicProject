using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicProject.Data;
using MusicProject.Models;
using MusicProject.Services.Users;
using MusicProject.ViewModels;

public class UserService : IUserService
{
    private readonly MusicProjectContext _musicProjectContext;

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(MusicProjectContext musicProjectContext, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _musicProjectContext = musicProjectContext;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _musicProjectContext.User.FindAsync(id);
    }



    public async Task<IdentityResult> RegisterUserAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result;
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
