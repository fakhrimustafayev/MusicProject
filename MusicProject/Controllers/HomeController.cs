using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicProject.Models;
using MusicProject.Services.Spotify;
using MusicProject.Services.Users;
using MusicProject.ViewModels;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using System.Security.Claims;

namespace MusicProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IUserService _userService;

        public HomeController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration, ISpotifyService spotifyService, IUserService userService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {


            var homeResponse = await _spotifyService.GetSpotifyHomepageAsync();
            var recommendations = await _spotifyService.GetRecommendationsAsync();
            List<string> artistIds = new List<string>
            {
                "1Xyo4u8uXC1ZmMpatF05PJ", "06HL4z0CvFAxyc27GXpf02", "66CXWjxzNUsdJxJ2JdwvnR",
                "5pKCCKE2ajJHZ9KAiaK11H", "3TVXtAsR1Inumwj472S9r4", "6vWDO969PvNqNYHIOW5v0m",
                "1uNFoZAHBGtllmzznpCI3s", "6M2wZ9GZgrQXHCFfjv46we", "5K4W6rqBFWDnAN6FQUkS6x",
                "4gzpq5DPGxSnKTe4SA8HAU", "0du5cEVh5yTK9QJze8zA0C", "7tYKF4w9nC0nq9CsPZTHyP",
                "1Cs0zKBU1kc0i8ypK3B9ai", "6eUKZXaKkcviH0Ku9w2n3V", "7dGJo4pcD2V6oG8kP0tJRR",
                "4q3ewBCX7sLwd24euuV69X", "5YGY8feqx7naU7z4HrwZM6", "0Y5tJX1MQlPlqiwlOH1tJY",
                "7CajNmpbOovFoOoasH2HaY", "0EmeFodog0BfCgMzAIvKQp"
            };

            var artistsData = await _spotifyService.GetArtistsDataAsync(artistIds);



            var model = new IndexViewModel
            {
                HomeResponse = homeResponse,
                TrackRecommendationResponse = recommendations,
                SpotifyArtistResponse = artistsData,
            };

            return View(model);

            

        }

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            var searchResult = await _spotifyService.SearchAsync(query);

            var viewModel = new IndexViewModel
            {
                SearchResponse = searchResult,
            };

    
            return View(viewModel);
        }



        public async Task<IActionResult> Users()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound(); 
            }

            var indexViewModel = new IndexViewModel
            {
                User = user,
            
            };

            return View(indexViewModel); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
