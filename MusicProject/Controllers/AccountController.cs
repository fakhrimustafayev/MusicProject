using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicProject.Areas.admin.ViewModels;
using MusicProject.Data;
using MusicProject.Models;
using MusicProject.Services.Users;
using MusicProject.ViewModels;
using System.Security.Claims;

namespace MusicProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly MusicProjectContext _context;


        public AccountController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager, MusicProjectContext context)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUserByUsername = await _userManager.FindByNameAsync(model.Username);

                if (existingUserByUsername != null)
                {
                    ModelState.AddModelError(string.Empty, "The username is already taken. Please choose a different one.");
                    return View(model);
                }

                // Proceed with user registration if no existing user is found
                var user = new User { UserName = model.Username, Email = model.Email, PhoneNumber = model.PhoneNumber };

                var result = await _userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Check if the user is an admin
                    var isAdmin = User.IsInRole("Admin"); // Assuming you have roles set up

                    // Redirect to different views based on user role
                    if (isAdmin)
                    {
                        // Redirect to Admin Dashboard or Admin-specific view
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    else
                    {
                        // Redirect to a general success view for non-admin users
                        return RedirectToAction("RegistrationSuccess", "Account");
                    }
                }

                // Handle other registration errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (model.Username == "Admin")
                    {
                        // Redirect to Admin Dashboard or Admin-specific view
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    else
                    {
                        // Redirect to the user's home page
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound(); // Or handle the case where the user is not found
            }

            var editUserViewModel = new EditUserViewModel
            {
               // Id = user.Id, // Assuming Id is a property in your EditUserViewModel
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
                // Other properties as needed
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Redirect to the home page upon successful update
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model); // If model state is invalid, return the edit view with validation errors
        }

        [HttpGet] // This action is for displaying the delete view, so it should use HTTP GET
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string username, string password)
        {
            var currentUser = await _userManager.GetUserAsync(User); // Get the current logged-in user

            var userToDelete = await _userManager.FindByNameAsync(username);
            if (userToDelete == null || userToDelete.Id != currentUser.Id) // Check if the user to delete is the current user
            {
                ModelState.AddModelError(string.Empty, "Invalid request.");
                return View("Delete"); // Return to the Delete view with the error message
            }

            // Validate the username and password
            var signInResult = await _signInManager.CheckPasswordSignInAsync(userToDelete, password, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View("Delete"); // Return to the Delete view with the error message
            }

            // Proceed with deleting the user if the credentials are correct
            await _userService.DeleteUserAsync(userToDelete.Id);
            return RedirectToAction("Login", "Account"); // Redirect to the login page after successful deletion
        }

        //// ToggleFavorite action in AccountController
        //[HttpPost]
        //public IActionResult ToggleFavorite(string trackId, bool isFavorite)
        //{
        //    var userId = _userManager.GetUserId(User);

        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return Json(new { success = false, message = "User not authenticated." });
        //    }

        //    try
        //    {
        //        var track = _context.Tracks.FirstOrDefault(t => t.id == trackId && t.UserId == userId);

        //        if (track == null)
        //        {
        //            // Create a new track object and mark it as favorite
        //            track = new SpoTrack
        //            {
        //                id = trackId,
        //                UserId = userId,
        //                IsFavorite = isFavorite,
        //                // Set other required properties such as 'name'
        //                name = "Default Track Name" // Example: Set a default name
        //            };
        //            _context.Tracks.Add(track);
        //        }
        //        else
        //        {
        //            // Toggle the favorite status
        //            track.IsFavorite = !isFavorite;
        //        }

        //        _context.SaveChanges();

        //        return Json(new { success = true, isFavorite = track.IsFavorite });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Error toggling favorite status: " + ex.Message });
        //    }
        //}



        //[HttpGet]
        //public IActionResult MyFavorites()
        //{
        //    var userId = _userManager.GetUserId(User); // Get the current user ID

        //    if (userId == null)
        //    {
        //        return RedirectToAction("Login", "Account"); // Redirect to login if user not authenticated
        //    }

        //    var favoriteTracks = _context.Tracks.Where(t => t.UserId == userId && t.IsFavorite).ToList();

        //    var viewModel = new IndexViewModel
        //    {
        //        FavoriteTracks = favoriteTracks
        //        // Initialize other properties of the view model as needed
        //    };

        //    return View(viewModel);
        //}




        [HttpGet]
        public IActionResult RegistrationSuccess()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        //public async Task<IActionResult> AddTrackToFavorites()
        //{
        //    _context.
        //}


    }

}
