using MusicProject.Models;

namespace MusicProject.ViewModels
{
    public class IndexViewModel
    {
        public HomeResponse HomeResponse { get; set; }
        public TrackRecommendationResponse TrackRecommendationResponse { get; set; }

        public List<SpoTrack> FavoriteTracks { get; set; }

        public SpotifyArtistResponse SpotifyArtistResponse { get; set; }

        public List<PlaylistTrack> PlaylistTrack {  get; set; }

        public SearchResponse SearchResponse { get; set; }
        public ArtistOverviewResponse ArtistOverviewResponse { get; set; }
        public IndexViewModel()
        {
            ArtistOverviewResponse = new ArtistOverviewResponse();
            ArtistTracks = new ArtistTracks();// Initialize the property
        }

        public User User { get; set; }

        public GetTrackResponse GetTrackResponse { get; set; }
        public List<GetTrackResponse> GetTrackResponses { get; set; }

        public List<GenreViewResponse> GenreViewResponses { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }

        public ArtistTracks ArtistTracks { get; set; }
   
    }
}
