using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MusicProject.Models;
using System.Linq;
using MusicProject.Data;
using MusicProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MusicProject.Services.Spotify;

namespace MusicProject.Controllers
{
    public class TrackController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly MusicProjectContext _context;
        private readonly ISpotifyService _spotifyService;

        public TrackController(MusicProjectContext context, UserManager<User> userManager, ISpotifyService spotifyService)
        {
            _context = context;
            _userManager = userManager;
            _spotifyService = spotifyService;
        }

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
        //            track = new SpoTrack
        //            {
        //                id = trackId,
        //                UserId = userId,
        //                IsFavorite = isFavorite,
        //                name = "Default Track Name"
        //            };
        //            _context.Tracks.Add(track);
        //        }
        //        else
        //        {
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
                .AnyAsync(uf => uf.UserId == currentUser.Id && uf.TrackId == trackId);

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


        //[Authorize] 
        //public async Task<IActionResult> MyFavorites()
        //{
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    if (currentUser == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var userWithFavorites = await _context.Users
        //        .Include(u => u.FavoriteTracks)
        //        //.ThenInclude(uf => uf.SpoTrack)
        //        .FirstOrDefaultAsync(u => u.Id == currentUser.Id);

        //    if (userWithFavorites == null)
        //    {
        //        return NotFound();
        //    }

        //    //var favoriteTracks = userWithFavorites.FavoriteTracks.Select(uf => uf.SpoTrack).ToList();

        //    return View(favoriteTracks);
        //}

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
