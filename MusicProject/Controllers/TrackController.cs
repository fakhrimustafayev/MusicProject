using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MusicProject.Models;
using System.Linq;
using MusicProject.Data;
using MusicProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MusicProject.Services.Spotify;
using Newtonsoft.Json;
using System.Net.Http;
using NuGet.DependencyResolver;

namespace MusicProject.Controllers
{
    public class TrackController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly MusicProjectContext _context;
        private readonly ISpotifyService _spotifyService;
        private readonly HttpClient _httpClient;

        public TrackController(MusicProjectContext context, UserManager<User> userManager, ISpotifyService spotifyService, HttpClient httpClient)
        {
            _context = context;
            _userManager = userManager;
            _spotifyService = spotifyService;
            _httpClient = httpClient;
        }



        [HttpPost]
        public async Task<IActionResult> AddToFavorites(string trackId)
        {
            if (string.IsNullOrEmpty(trackId))
            {
                return BadRequest("Track ID is required.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var track = await _context.SpoTracks.FindAsync(trackId);
            if (track == null)
            {
                return NotFound();
            }

            var alreadyFavorite = await _context.UserFavorites
                .AnyAsync(uf => uf.UserId == currentUser.Id && uf.TrackId     == trackId);

            if (!alreadyFavorite)
            {
                var userFavorite = new UserFavorite
                {
                    UserId = currentUser.Id,
                    TrackId = trackId
                };

                _context.UserFavorites.Add(userFavorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyFavorites", "Track");
        }


        [Authorize]
        public async Task<IActionResult> MyFavorites()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            }

       

            var vm = new IndexViewModel();
            var favs=await  _context.UserFavorites.Where(x => x.UserId == currentUser.Id).ToListAsync();
            var list = new List<GetTrackResponse>();
     
            foreach (var x in favs)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://spotify23.p.rapidapi.com/tracks/?ids={x.TrackId}"),
                    Headers =
        {
            { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
            { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
        },
                };
                Console.WriteLine($"https://spotify23.p.rapidapi.com/tracks/?ids={x.TrackId}");

                using (var response = await _httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var track = JsonConvert.DeserializeObject<GetTrackResponse>(jsonString);
                    list.Add(track);
                }
            }

            vm.GetTrackResponses=list;

            return View(vm);

        }

        // GET: /Track/GetTrack?id=trackId
        public async Task<IActionResult> GetTrack(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Track ID is required.");
            }

            // Call the SpotifyService to get track details
            var track = await _spotifyService.GetTrackInfoAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            // Assuming IndexViewModel has a property to store the track details
            var viewModel = new IndexViewModel
            {
                GetTrackResponse = track // Assuming IndexViewModel has a property called Track of type GetTrackResponse
            };

            return View(viewModel); // Pass the viewModel instance to the view
        }


    }
}
