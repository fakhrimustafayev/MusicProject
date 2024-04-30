using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicProject.Models;
using MusicProject.ViewModels;
using System.Security.Principal;

namespace MusicProject.Services.Users;

public interface IUserService 
{
    Task<User> GetUserById(string userId);
    IEnumerable<User> GetAllUsers();
    Task<IdentityResult> RegisterUserAsync(User user, string password);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string id);
}
