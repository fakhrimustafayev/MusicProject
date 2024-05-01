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
        public async Task<IActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    // User creation succeeded, redirect to the Index action in the admin/Home controller
                    return RedirectToAction("Index", "Home", new { area = "admin" });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If ModelState is not valid or user creation failed, return to the view with errors
            return View(user); // Assuming you have a view for adding users
        }





        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new AdminViewModel(0) // Pass appropriate value for TotalUsers
            {
                User = user
            };

            return View(model); // Pass the AdminViewModel instance to the view
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _userManager.FindByIdAsync(id);
                    existingUser.UserName = user.UserName;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;

                    var result = await _userManager.UpdateAsync(existingUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(user); // Return to the edit view with errors if ModelState is not valid
        }

        private bool UserExists(string id)
        {
            return _userManager.Users.Any(u => u.Id == id);
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