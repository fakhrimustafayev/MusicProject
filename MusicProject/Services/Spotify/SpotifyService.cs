using Azure;
using MusicProject.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MusicProject.Services.Spotify
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "spotify81.p.rapidapi.com");
        }
        //public async Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //    var response = await _httpClient.GetAsync($"browse/new-releases?country={countryCode}&limit={limit}");

        //    response.EnsureSuccessStatusCode();

        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

        //    return responseObject?.albums?.items.Select(i => new Release
        //    {
        //        Name = i.name,
        //        Date = i.release_date,
        //        ImageUrl = i.images.FirstOrDefault().url,
        //        Link = i.external_urls.spotify,
        //        Artists = string.Join(",", i.artists.Select(i => i.name))
        //    });
        //}

        public async Task<string> GetTopTracks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/top_200_tracks?country=GLOBAL&period=daily&date=2024-02-20"),
                Headers =
            {
                { "X-RapidAPI-Key", "60a9cfe6d2msh13aac0c162051a7p127a68jsna4b43aa8008b" },
                { "X-RapidAPI-Host", "spotify81.p.rapidapi.com" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public async Task<PlaylistResponse> GetPlaylistAsync(string playlistId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify81.p.rapidapi.com/playlist?id={playlistId}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                    { "X-RapidAPI-Host", "spotify81.p.rapidapi.com" },
                },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore // Ignore null properties
                };
                var playlistResponse = JsonConvert.DeserializeObject<PlaylistResponse>(body, settings);
                return playlistResponse;
            }
        }

        public async Task<List<PlaylistTrack>> GetPlaylistTracksAsync(string playlistId)
        {
            var response = await _httpClient.GetAsync($"https://spotify81.p.rapidapi.com/playlist_tracks?id={playlistId}&offset=0&limit=100");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var playlistTracks = JsonConvert.DeserializeObject<PlaylistResponse>(jsonString);
            var a = 100;
            return playlistTracks?.Items;
        }
    }
    }