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

        public async Task<string> GetTopTracks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/top_200_tracks?country=GLOBAL&period=daily&date=2024-02-20"),
                Headers =
            {
                { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
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
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify81.p.rapidapi.com/playlist_tracks?id={playlistId}&offset=0&limit=100"),
                Headers =
        {
            { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
            { "X-RapidAPI-Host", "spotify81.p.rapidapi.com" },
        },
            };

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var playlistTracks = JsonConvert.DeserializeObject<PlaylistResponse>(jsonString);

                return playlistTracks?.Items;
            }
        }


        public async Task<HomeResponse> GetSpotifyHomepageAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify-web-api3.p.rapidapi.com/v1/social/spotify/homepage"),
                Headers =
            {
                { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                { "X-RapidAPI-Host", "spotify-web-api3.p.rapidapi.com" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var homeResponse = JsonConvert.DeserializeObject<HomeResponse>(jsonString);
                return homeResponse;
            }
        }

        public async Task<List<PodcastEpisode>> GetPodcastEpisodesAsync(string episodeId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify-scraper.p.rapidapi.com/v1/episode/details?episodeId={episodeId}"),
                Headers =
        {
            { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
            { "X-RapidAPI-Host", "spotify-scraper.p.rapidapi.com" },
        },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var episodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(jsonString);
                return episodeResponse?.Episodes?.Items;
            }
        }

        public async Task<TrackRecommendationResponse> GetRecommendationsAsync()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify23.p.rapidapi.com/recommendations/?limit=50&seed_tracks=0c6xIDDpzE81m2q797ordA&seed_artists=4NHQUGzhtTLFvgF5SZesLK&seed_genres=classical%2Ccountry"),
                Headers =
         {
              { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
              { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
        },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var tracks = JsonConvert.DeserializeObject<TrackRecommendationResponse>(jsonString);
                return tracks;
            }
        }

        public async Task<SpotifyArtistResponse> GetArtistsDataAsync(List<string> artistIds)
        {
                var requestUri = $"https://spotify23.p.rapidapi.com/artists/?ids={string.Join(",", artistIds)}";
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                    Headers =
            {
                { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
            },
                };

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var artistsResponse = System.Text.Json.JsonSerializer.Deserialize<SpotifyArtistResponse>(responseBody);

                // Check if artistsResponse is not null and contains data
                if (artistsResponse != null && artistsResponse.artists != null)
                {
                    return artistsResponse;
                }

                return new SpotifyArtistResponse(); // Return an empty response if no data is available

        }


        public async Task<ArtistOverviewResponse> GetArtistOverviewAsync(string artistId)
        {
            var requestUri = $"https://spotify81.p.rapidapi.com/artist_overview?id={artistId}";

            try
            {
                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into an instance of ArtistOverviewResponse
                var artistOverview = JsonConvert.DeserializeObject<ArtistOverviewResponse>(body);

                return artistOverview;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching artist overview: {ex.Message}");
                return null;
            }
        }


        public async Task<List<GenreViewResponse>> GetGenreViewsAsync(List<string> genreIds)
        {
            var genreViews = new List<GenreViewResponse>();

            foreach (var genreId in genreIds)
            {
                var requestUri = $"https://spotify23.p.rapidapi.com/genre_view/?id={genreId}&content_limit=10&limit=50";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                    Headers =
    {
        { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
        { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
    },
                };

                var response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the response body into GenreViewResponse object
                var genreView = JsonConvert.DeserializeObject<GenreViewResponse>(responseBody);

                genreViews.Add(genreView); // Add the GenreViewResponse object to the list
            }

            return genreViews;
        }


        public async Task<SearchResponse> SearchAsync(string query)
        {
            var requestUri = $"https://spotify23.p.rapidapi.com/search/?q={query}&type=track&offset=0&limit=15&numberOfTopResults=5";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
                {
                    { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                    { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
                },
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<SearchResponse>(responseBody);
            return searchResult;
        }

        public async Task<GetTrackResponse> GetTrackInfoAsync(string trackId)
        {
            // Create the request message
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify23.p.rapidapi.com/tracks/?ids={trackId}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                    { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
                },
            };

            // Send the request and get the response
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var track = JsonConvert.DeserializeObject<GetTrackResponse>(jsonString);
                return track;
            }
        }

        public async Task<ArtistTracks> GetArtistTracksAsync(string artistId)
        {
            // Construct the request message
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify23.p.rapidapi.com/artist_singles/?id={artistId}&offset=0&limit=20"),
                Headers =
            {
                { "X-RapidAPI-Key", "67b9737f4cmsh37dac4a6c03c434p15a99cjsn7c13997ec06a" },
                { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
            },
            };

            // Send the request and process the response
            using (var response = await _httpClient.SendAsync(request))
            {
                // Ensure a successful response
                response.EnsureSuccessStatusCode();

                // Read the response body as a string
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response to your model class
                var artistTracks = Newtonsoft.Json.JsonConvert.DeserializeObject<ArtistTracks>(responseBody);

                return artistTracks;
            }
        }
    }


}
