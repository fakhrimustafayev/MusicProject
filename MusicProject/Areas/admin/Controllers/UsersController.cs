using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MusicProject.Areas.admin.ViewModels;
using MusicProject.Models;

namespace MusicProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userIdMap = new Dictionary<string, int>();
            for (int i = 0; i < users.Count; i++)
            {
                userIdMap[users[i].Id] = i + 1;
            }
            var model = new AdminViewModel(users.Count)
            {
                Users = users,
                UserIdMap = userIdMap
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            // Your logic to prepare the view for adding a new user
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(newUser);
                if (result.Succeeded)
                {
                    return Json(new { success = true, message = "User added successfully" });
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return Json(new { success = false, message = "Failed to add user: " + errors });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid user data" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User editedUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(editedUser.Id);
                if (existingUser != null)
                {
                    existingUser.UserName = editedUser.UserName;
                    existingUser.Email = editedUser.Email;

                    var result = await _userManager.UpdateAsync(existingUser);
                    if (result.Succeeded)
                    {
                        return Json(new { success = true, message = "User edited successfully" });
                    }
                    else
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        return Json(new { success = false, message = "Failed to edit user: " + errors });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "User not found" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid user data" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Json(new { success = true, message = "User deleted successfully" });
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return Json(new { success = false, message = "Failed to delete user: " + errors });
                }
            }
            else
            {
                return Json(new { success = false, message = "User not found" });
            }
        }
    }
}

