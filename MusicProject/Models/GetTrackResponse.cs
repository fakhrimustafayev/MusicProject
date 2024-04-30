namespace MusicProject.Models
{
    public class GetTrackResponse
    {
        public GetTrack[] tracks { get; set; }
    }

    public class GetTrack
    {
        public TrackAlbum album { get; set; }
        public Artist1[] artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public TrackExternal_Ids external_ids { get; set; }
        public TrackExternal_Urls2 external_urls { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public TrackLinked_From linked_from { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TrackAlbum
    {
        public string album_type { get; set; }
        public TrackArtist[] artists { get; set; }
        public TrackExternal_Urls external_urls { get; set; }
        public string id { get; set; }
        public TrackImage[] images { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TrackExternal_Urls
    {
        public string spotify { get; set; }
    }

    public class TrackArtist
    {
        public TrackExternal_Urls1 external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TrackExternal_Urls1
    {
        public string spotify { get; set; }
    }

    public class TrackImage
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class TrackExternal_Ids
    {
        public string isrc { get; set; }
    }

    public class TrackExternal_Urls2
    {
        public string spotify { get; set; }
    }

    public class TrackLinked_From
    {
        public TrackExternal_Urls3 external_urls { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TrackExternal_Urls3
    {
        public string spotify { get; set; }
    }

    public class Artist1
    {
        public External_Urls4 external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls4
    {
        public string spotify { get; set; }
    }

}
