using MusicProject.Models;

namespace MusicProject.Services.Spotify
{
    public interface ISpotifyService
    {
        //Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
         Task<string> GetTopTracks();

        Task<PlaylistResponse> GetPlaylistAsync(string playlistId);
        Task<List<PlaylistTrack>> GetPlaylistTracksAsync(string playlistId);

    }
}
