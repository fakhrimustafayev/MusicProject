using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MusicProject.Areas.admin.ViewModels;
using MusicProject.Models;
using MusicProject.Services.Users;
using System.Linq;
using System.Threading.Tasks;

namespace MusicProject.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public HomeController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [Area("admin")]
        public IActionResult Index()
        {
            var allUsers = _userService.GetAllUsers();
            var usersList = allUsers.ToList();

            var viewModel = new AdminViewModel(usersList.Count())
            {
                Users = usersList,
                UserIdMap = usersList.Select((user, index) => new { Id = user.Id.ToString(), Index = index + 1 })
                                    .ToDictionary(x => x.Id, x => x.Index)
            };

            return View(viewModel);
        }

        [Area("admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var userToDelete = await _userManager.FindByIdAsync(userId);
            if (userToDelete == null)
            {
                return NotFound(); 
            }

            await _userService.DeleteUserAsync(userId);
            return RedirectToAction("Index", "Home", new { area = "admin" });
        }
    }
}

