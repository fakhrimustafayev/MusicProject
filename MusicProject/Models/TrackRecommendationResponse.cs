using System.ComponentModel.DataAnnotations.Schema;

namespace MusicProject.Models
{
    public class TrackRecommendationResponse
    {
        public SpoTrack[] tracks { get; set; }
    }

    public class SpoTrack
    {
        public SpoAlbum album { get; set; }
        [NotMapped]
        public SpoArtist[] artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool IsExplicit { get; set; } 
        //[NotMapped]
        public External_Ids external_ids { get; set; }
        public External_Urls2 external_urls { get; set; }
        public string id { get; set; }

        public string UserId { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public Linked_From linked_from { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }

        public bool IsFavorite { get; set; }
    }

   // [NotMapped]
    public class SpoAlbum
    {
        public string album_type { get; set; }
        public SpoArtist[] artists { get; set; }
        public string[] available_markets { get; set; }
       // [NotMapped]
        public External_Urls external_urls { get; set; }
        public string id { get; set; }
        public SpoImage[] images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class SpoArtist
    {
        public string AlbumId { get; set; }
        public SpoAlbum Album { get; set; }
        public External_Urls1 external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls
    {
        public string spotify { get; set; }
    }

    public class SpoImage
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class External_Ids
    {
        public string isrc { get; set; }
    }

    public class External_Urls1
    {
        public string spotify { get; set; }
    }

    public class External_Urls2
    {
        public string spotify { get; set; }
    }

    public class Linked_From
    {
        public External_Urls3 external_urls { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls3
    {
        public string spotify { get; set; }
    }
}
