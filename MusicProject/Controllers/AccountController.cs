
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                    var isAdmin = User.IsInRole("Admin"); 

                    
                    if (isAdmin)
                    {
             
                        return RedirectToAction("Index", "Home", new { area = "admin" });
                    }
                    else
                    {

                        return RedirectToAction("RegistrationSuccess", "Account");
                    }
                }


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
                return NotFound();
            }

            var editUserViewModel = new EditUserViewModel
            {

                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model); 
        }

        [HttpGet] 
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string username, string password)
        {
            var currentUser = await _userManager.GetUserAsync(User); // Get the current logged-in user

            var userToDelete = await _userManager.FindByNameAsync(username);
            if (userToDelete == null || userToDelete.Id != currentUser.Id) 
            {
                ModelState.AddModelError(string.Empty, "Invalid request.");
                return View("Delete"); 
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(userToDelete, password, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View("Delete"); 
            }

            await _userService.DeleteUserAsync(userToDelete.Id);
            return RedirectToAction("Login", "Account"); 
        }



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


        public async Task<IActionResult> AddTrackToFavorites(string id)
        {
            var userid = _userManager.GetUserId(User);
          var resp=await _context.UserFavorites.Where(x =>
           
                x.TrackId == id && x.UserId == userid
  
            ).FirstOrDefaultAsync();
            if (resp != null)
            {
                _context.UserFavorites.Remove(resp);
                await _context.SaveChangesAsync();

            }
            else
            {
                await _context.UserFavorites.AddAsync(new() { UserId = userid, TrackId = id });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index","home");
        }


    }

}
