using Microsoft.AspNetCore.Mvc;
using MusicProject.Data;
using MusicProject.Models;
using MusicProject.Services.Spotify;
using MusicProject.ViewModels;
using System.Threading.Tasks;

namespace MusicProject.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicProjectContext _context;
        private readonly ISpotifyService _spotifyService;

        public ArtistsController(MusicProjectContext context, ISpotifyService spotifyService)
        {
            _context = context;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index(string id)
        {
            // Call GetArtistOverviewAsync to fetch detailed artist data
            var artistOverview = await _spotifyService.GetArtistOverviewAsync(id);

            // Call GetArtistTracksAsync to fetch tracks for the artist
            var artistTracks = await _spotifyService.GetArtistTracksAsync(id);

            // Create an IndexViewModel and assign the artistOverview and artistTracks
            var viewModel = new IndexViewModel
            {
                ArtistOverviewResponse = artistOverview,
                ArtistTracks = artistTracks
            };

            // Pass the viewModel to the view for display
            return View(viewModel);
        }



    }
}
