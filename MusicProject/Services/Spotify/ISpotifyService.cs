using MusicProject.Models;

namespace MusicProject.Services.Spotify
{
    public interface ISpotifyService
    {
         Task<string> GetTopTracks();

        Task<PlaylistResponse> GetPlaylistAsync(string playlistId);
        Task<List<PlaylistTrack>> GetPlaylistTracksAsync(string playlistId);

         Task<HomeResponse> GetSpotifyHomepageAsync();

        Task<List<PodcastEpisode>> GetPodcastEpisodesAsync(string episodeId);

        Task<TrackRecommendationResponse> GetRecommendationsAsync();

        Task<SpotifyArtistResponse> GetArtistsDataAsync(List<string> artistIds);

        Task<ArtistOverviewResponse> GetArtistOverviewAsync(string artistId);

        Task<List<GenreViewResponse>> GetGenreViewsAsync(List<string> genreIds);

        Task<SearchResponse> SearchAsync(string query);

        Task<GetTrackResponse> GetTrackInfoAsync(string trackId);

        Task<ArtistTracks> GetArtistTracksAsync(string artistId);


    }
}
