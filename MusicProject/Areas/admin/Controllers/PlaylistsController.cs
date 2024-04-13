using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicProject.Data;
using MusicProject.Models;
using Newtonsoft.Json;

namespace MusicProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class PlaylistsController : Controller
    {
        private readonly MusicProjectContext _context;

        public PlaylistsController(MusicProjectContext context)
        {
            _context = context;
        }


        // GET: admin/Playlists
        public async Task<IActionResult> Index()
        {
          

            return View(await _context.Playlist.ToListAsync());
        }


     



        // GET: admin/Playlists/Details/5
        public async Task<IActionResult> Details()
        {

            //var tracks = GetTracksFromFolder("wwwroot/assets/80s");
            //return View(tracks);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var playlist = await _context.Playlist
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (playlist == null)
            //{
            //    return NotFound();
            //}

            //return View(playlist);
            return View();
        }



        // GET: admin/Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: admin/Playlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: admin/Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: admin/Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: admin/Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
            return _context.Playlist.Any(e => e.Id == id);
        }


    }
}

//if (id == null)
//{
//    return NotFound();
//}

//// Получение информации о плейлисте из Deezer API
//var httpClient = new HttpClient();
//var response = await httpClient.GetAsync($"https://api.deezer.com/playlist/{id}");

//if (response.IsSuccessStatusCode)
//{
//    // Прочитайте содержимое ответа
//    var content = await response.Content.ReadAsStringAsync();

//    // Десериализуйте JSON-данные в объект Playlist
//    var playlistInfo = JsonConvert.DeserializeObject<Playlist>(content);

//    if (playlistInfo == null)
//    {
//        return NotFound();
//    }

//    // Получите ссылку на треклист плейлиста
//    var tracklistResponse = await httpClient.GetAsync(playlistInfo.Tracklist);
//    if (!tracklistResponse.IsSuccessStatusCode)
//    {
//        return NotFound();
//    }

//    var tracklistContent = await tracklistResponse.Content.ReadAsStringAsync();
//    var tracklist = JsonConvert.DeserializeObject<Tracklist>(tracklistContent);

//    if (tracklist == null)
//    {
//        return NotFound();
//    }

//    // Передача информации о плейлисте и его треках в представление
//    var viewModel = new PlaylistViewModel
//    {
//        PlaylistInfo = playlistInfo,
//        Tracklist = tracklist.Data
//    };

//    return View(viewModel);
//}
//else
//{
//    return NotFound();
//}

//private async Task<List<Track>> GetSongsFromDeviceAsync()
//{
//    var songs = new List<Track>();

//    // Path to the folder containing your songs
//    string folderPath = @"C:\Users\User\Music\80s Songs for Weddings ♫ Top Love 1980s Wedding Music Playlist";

//    // Check if the folder exists
//    if (Directory.Exists(folderPath))
//    {
//        // Get all files with supported audio extensions from the folder
//        var audioFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
//            .Where(file => file.EndsWith(".mp3") || file.EndsWith(".wav") || file.EndsWith(".ogg"))
//            .ToList();

//        // Iterate over the audio files and create Song objects
//        int songNumber = 1;
//        foreach (var file in audioFiles)
//        {
//            var song = new Track
//            {
//                Id = songNumber++,
//                Title = Path.GetFileNameWithoutExtension(file),
//                // You can set the artist based on file metadata
//                // You can set the album based on file metadata
//                Duration = 0      // You can get the duration from file metadata     
//            };

//            songs.Add(song);
//        }
//    }

//    return songs;
//}


//private List<Track> GetTracksFromFolder(string folderPath)
//{
//    var tracks = new List<Track>();

//    var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), folderPath);

//    if (Directory.Exists(directoryPath))
//    {
//        var mp3Files = Directory.GetFiles(directoryPath, "*.mp3");

//        foreach (var mp3File in mp3Files)
//        {
//            var fileName = Path.GetFileName(mp3File);
//            tracks.Add(new Track
//            {
//                Id = tracks.Count + 1,
//                Title = Path.GetFileNameWithoutExtension(fileName),
//                FilePath = Path.Combine(folderPath, fileName)
//            });
//        }
//    }

//    return tracks;
//}

















































//using (var client = new HttpClient())
//{
//    // Выполните HTTP-запрос к API Deezer
//    var response = await client.GetAsync("https://api.deezer.com/playlist/1950353862");

//    // Проверьте, был ли запрос успешным
//    if (response.IsSuccessStatusCode)
//    {
//        // Прочитайте содержимое ответа
//        var content = await response.Content.ReadAsStringAsync();

//        // Десериализуйте JSON-ответ в объект Playlist
//        var playlist = JsonConvert.DeserializeObject<Playlist>(content);

//        // Передайте объект плейлиста в представление
//        return View(playlist);
//    }
//    else
//    {
//        // Обработайте ошибку, если запрос не удался
//        return View("Error");
//    }
//}