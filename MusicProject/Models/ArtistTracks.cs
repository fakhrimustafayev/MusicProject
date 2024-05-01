namespace MusicProject.Models;
//{
//    public class PlaylistViewModel
//    {
//        public Playlist PlaylistInfo { get; set; }
//        public List<Track> Tracklist { get; set; }
//    }
//}

public class ArtistTracks
{
    public ArtistTracksData data { get; set; }
    public object[] extensions { get; set; }
}

public class ArtistTracksData
{
    public ArtistTracksArtist artist { get; set; }
}

public class ArtistTracksArtist
{
    public ArtistTracksDiscography discography { get; set; }
}

public class ArtistTracksDiscography
{
    public ArtistTracksSingles singles { get; set; }
}

public class ArtistTracksSingles
{
    public int totalCount { get; set; }
    public ArtistTracksItem[] items { get; set; }
}

public class ArtistTracksItem
{
    public ArtistTracksReleases releases { get; set; }
}

public class ArtistTracksReleases
{
    public ArtistTracksItem1[] items { get; set; }
}

public class ArtistTracksItem1
{
    public string id { get; set; }
    public string uri { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public ArtistTracksDate date { get; set; }
    public ArtistTracksCoverart coverArt { get; set; }
    public ArtistTracksPlayability playability { get; set; }
    public ArtistTracksSharinginfo sharingInfo { get; set; }
    public ArtistTracksTracks tracks { get; set; }
}

public class ArtistTracksDate
{
    public int year { get; set; }
    public DateTime isoString { get; set; }
}

public class ArtistTracksCoverart
{
    public ArtistTracksSource[] sources { get; set; }
}

public class ArtistTracksSource
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class ArtistTracksPlayability
{
    public bool playable { get; set; }
    public string reason { get; set; }
}

public class ArtistTracksSharinginfo
{
    public string shareId { get; set; }
    public string shareUrl { get; set; }
}

public class ArtistTracksTracks
{
    public int totalCount { get; set; }
}
