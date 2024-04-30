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
            //var newReleases = await GetReleases();
            //return View(newReleases);

            //var topTracksResponse = await _spotifyService.GetTopTracks();
            //var topTracks = JsonConvert.DeserializeObject<List<SpotifyTrack>>(topTracksResponse);
            //return View(topTracks);



            //var playlistResponse = await _spotifyService.GetPlaylistAsync(playlistId);
            //ViewBag.PlaylistResponse = playlistResponse;
            //return View(playlistResponse);

            //var playlistId = "37i9dQZF1DX4Wsb4d7NKfP";
            //var tracks = await _spotifyService.GetPlaylistTracksAsync(playlistId);
            //return View(tracks);

            //var homeResponse = await _spotifyService.GetSpotifyHomepageAsync();
            //return View(homeResponse);

            //string episodeId = "3LEK1k9KaFRLAmPwMbj3o9"; // Replace with the actual episode ID you want to fetch
            //var episodes = await _spotifyService.GetPodcastEpisodesAsync(episodeId);
            //return View(episodes);

            //var recommendations = await _spotifyService.GetRecommendationsAsync();
            //return View(recommendations);

            //var topArtists = await _spotifyService.GetTopArtistsAsync();
            //return View(topArtists);

            //var relatedArtists = await _spotifyService.GetRelatedArtistsAsync();
            //return View(relatedArtists);



            //var artistId = "2w9zwq3AktTeYYMuhMjju8"; // Replace with actual artist ID
            //var artistOverview = await _spotifyService.GetArtistOverviewAsync(artistId);

            //// Do something with the artist overview, such as passing it to the view
            //return View(artistOverview);

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

            //var trackId = "4WNcduiCmDNfmTEz7JvmLv";

           // var trackResponse = await _spotifyService.GetTrackInfoAsync("4WNcduiCmDNfmTEz7JvmLv");
            //return View(artistsData);

            var model = new IndexViewModel
            {
                HomeResponse = homeResponse,
                TrackRecommendationResponse = recommendations,
                SpotifyArtistResponse = artistsData,
              //  GetTrackResponse = trackResponse
            };

            return View(model);

            

        }

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                // Handle empty or invalid input
                return RedirectToAction("Index");
            }

            var searchResult = await _spotifyService.SearchAsync(query);

            var viewModel = new IndexViewModel
            {
                SearchResponse = searchResult,
            };

            // Pass the search result to the view
            return View(viewModel);
        }


        //private async Task<IEnumerable<Release>> GetReleases()
        //{
        //    try
        //    {
        //        var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

        //        var newReleases = await _spotifyService.GetNewReleases("US", 20, token);

        //        return newReleases;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Write(ex);

        //        return Enumerable.Empty<Release>();
        //    }
        //}

        public async Task<IActionResult> Users()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound(); // Or handle the case where the user is not found
            }

            // Assuming you have a service or method to populate the other properties of IndexViewModel
            var indexViewModel = new IndexViewModel
            {
                User = user,
                // Populate other properties as needed
            };

            return View(indexViewModel); // Pass IndexViewModel to the view
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
