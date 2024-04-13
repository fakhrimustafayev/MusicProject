using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicProject.Models;
using MusicProject.Services.Spotify;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;

namespace MusicProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly ISpotifyAccountService _spotifyAccountService;

        public HomeController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration, ISpotifyService spotifyService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index()
        {
            //var newRelease = await GetReleases();

            //var topTracksResponse = await _spotifyService.GetTopTracks();
            //var topTracks = JsonConvert.DeserializeObject<List<SpotifyTrack>>(topTracksResponse);
            //return View(topTracks);

            var playlistId = "37i9dQZF1DX4Wsb4d7NKfP";

            //var playlistResponse = await _spotifyService.GetPlaylistAsync(playlistId);
            //ViewBag.PlaylistResponse = playlistResponse;
            //return View(playlistResponse);

            var tracks = await _spotifyService.GetPlaylistTracksAsync(playlistId);
            return View(tracks);
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

        public IActionResult Users()
        {
            return View();
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
