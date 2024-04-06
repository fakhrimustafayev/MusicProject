//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MusicProject.Data;
//using MusicProject.Models;
//using System.Net.Http.Headers;
//using Newtonsoft.Json;

//namespace MusicProject.Areas.admin.Controllers
//{
//    [Area("admin")]
//    public class ArtistsController : Controller
//    {
//        private readonly MusicProjectContext _context;

//        public ArtistsController(MusicProjectContext context)
//        {
//            _context = context;
//        }

//        // GET: admin/Artists
//        public async Task<IActionResult> Index(int id)
//        {
//            var client = new HttpClient();
//            var request = new HttpRequestMessage
//            {
//                Method = HttpMethod.Get,
//                RequestUri = new Uri($"https://deezerdevs-deezer.p.rapidapi.com/artist/{id}"),
//                Headers =
//        {
//            { "X-RapidAPI-Key", "60a9cfe6d2msh13aac0c162051a7p127a68jsna4b43aa8008b" },
//            { "X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com" },
//        },
//            };

//            using (var response = await client.SendAsync(request))
//            {
//                response.EnsureSuccessStatusCode();
//                var body = await response.Content.ReadAsStringAsync();
//                Singer art = JsonConvert.DeserializeObject<Singer>(body);

//                // Создаем коллекцию из одного артиста
//                List<Singer> artists = new List<Singer>();
//                artists.Add(art);

//                return View(artists);
//            }
//        }


//        // GET: admin/Artists/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var artist = await _context.Artist
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (artist == null)
//            {
//                return NotFound();
//            }

//            return View(artist);
//        }

//        // GET: admin/Artists/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: admin/Artists/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name")] Singer artist)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(artist);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(artist);
//        }

//        // GET: admin/Artists/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var artist = await _context.Artist.FindAsync(id);
//            if (artist == null)
//            {
//                return NotFound();
//            }
//            return View(artist);
//        }

//        // POST: admin/Artists/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Singer artist)
//        {
//            if (id != artist.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(artist);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ArtistExists(artist.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(artist);
//        }

//        // GET: admin/Artists/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var artist = await _context.Artist
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (artist == null)
//            {
//                return NotFound();
//            }

//            return View(artist);
//        }

//        // POST: admin/Artists/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var artist = await _context.Artist.FindAsync(id);
//            if (artist != null)
//            {
//                _context.Artist.Remove(artist);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ArtistExists(int id)
//        {
//            return _context.Artist.Any(e => e.Id == id);
//        }
//    }
//}
