namespace MusicProject.Models
{
    public class PlaylistTrack
    {
        public DateTime AddedAt { get; set; }
        public List<Artist> Artists { get; set; }
        public Album Album { get; set; }
        public AddedBy AddedBy { get; set; }
        public Track Track { get; set; }
    }

    public class AddedBy
    {
        public string Spotify { get; set; }
    }

    public class Track
    {
       public List<Artist> Artists { get; set; }
        public string Preview_Url { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public bool IsLocal { get; set; }
        public Album Album { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Id { get; set; }

        public int Popularity { get; set; }
    }

    public class Album
    {
        public List<Artist> Artists { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public List<Image> Images { get; set; } // Update Images property type
    }

    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }
    public class Artist
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    public class PlaylistResponse
    {
        public List<PlaylistTrack> Items { get; set; }
    }


}
