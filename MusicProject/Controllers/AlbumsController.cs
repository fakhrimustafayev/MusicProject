﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MusicProject.Data;
using MusicProject.Models;
using MusicProject.Services.Spotify;
using MusicProject.ViewModels;

namespace MusicProject.Controllers
{
    public class AlbumsController : Controller
    {

        private readonly MusicProjectContext _context;
        private readonly ISpotifyService _spotifyService;

        public AlbumsController(MusicProjectContext context, ISpotifyService spotifyService)
        {
            _context = context;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index()
        {
            // Display the list of genres for selection
            return View();
        }

        public async Task<IActionResult> Pop()
        {
            var genreId = "0JQ5DAqbMKFEC4WFtoNRpw"; // Pop genre ID
            var genreViewResponses = await _spotifyService.GetGenreViewsAsync(new List<string> { genreId });

            var viewModel = new IndexViewModel
            {
                GenreViewResponses = genreViewResponses
            };

            return View("Pop", viewModel); 
        }

        public async Task<IActionResult> HipHop()
        {
            var genreId = "0JQ5DAqbMKFQ00XGBls6ym"; // Hip-hop genre ID
            var genreViewResponses = await _spotifyService.GetGenreViewsAsync(new List<string> { genreId });

            var viewModel = new IndexViewModel
            {
                GenreViewResponses = genreViewResponses
            };

            return View("HipHop", viewModel); 
        }


        public async Task<IActionResult> Rock()
        {
            var genreId = "0JQ5DAqbMKFDXXwE9BDJAr"; // Pop genre ID
            var genreViewResponses = await _spotifyService.GetGenreViewsAsync(new List<string> { genreId });

            var viewModel = new IndexViewModel
            {
                GenreViewResponses = genreViewResponses
            };

            return View("Rock", viewModel);
        }

        public async Task<IActionResult> Jazz()
        {
            var genreId = "0JQ5DAqbMKFAJ5xb0fwo9m"; // Hip-hop genre ID
            var genreViewResponses = await _spotifyService.GetGenreViewsAsync(new List<string> { genreId });

            var viewModel = new IndexViewModel
            {
                GenreViewResponses = genreViewResponses
            };

            return View("Jazz", viewModel); 
        }

        public async Task<IActionResult> Classical()
        {
            var genreId = "0JQ5DAqbMKFPrEiAOxgac3"; // Pop genre ID
            var genreViewResponses = await _spotifyService.GetGenreViewsAsync(new List<string> { genreId });

            var viewModel = new IndexViewModel
            {
                GenreViewResponses = genreViewResponses
            };

            return View("Classical", viewModel); 
        }



    }
}
