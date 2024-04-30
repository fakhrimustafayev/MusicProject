using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public async Task<User> GetUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }



    public async Task<IdentityResult> RegisterUserAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result;
    }

    public async Task UpdateUserAsync(User user)
    {
        _musicProjectContext.Attach(user).State = EntityState.Modified;
        await _musicProjectContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(string id)
    {
        var userToDelete = await _userManager.FindByIdAsync(id);
        if (userToDelete != null)
        {
            await _userManager.DeleteAsync(userToDelete);
        }
    }


    public IEnumerable<User> GetAllUsers()
    {
        return _musicProjectContext.User.ToList(); // Возвращаем копию списка пользователей
    }

}
