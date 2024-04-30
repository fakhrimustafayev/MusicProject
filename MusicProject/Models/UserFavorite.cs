namespace MusicProject.Models
{
    public class UserFavorite
    {
        public string UserId { get; set; }
        public string TrackId { get; set; }

        // Navigation properties
        //public User User { get; set; }
        //public SpoTrack SpoTrack { get; set; }
    }
}
