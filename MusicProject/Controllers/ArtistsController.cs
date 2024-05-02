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

            var artistOverview = await _spotifyService.GetArtistOverviewAsync(id);

            var artistTracks = await _spotifyService.GetArtistTracksAsync(id);


            var viewModel = new IndexViewModel
            {
                ArtistOverviewResponse = artistOverview,
                ArtistTracks = artistTracks
            };


            return View(viewModel);
        }



    }
}
