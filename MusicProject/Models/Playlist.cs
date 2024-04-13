using System.Security.Policy;

namespace MusicProject.Models;

public class Playlist
{
    public int Id { get; set; }
    public string Title { get; set; }

   // public List<Track> Tracks { get; set; }

    public int Duration { get; set; }
    public bool Public { get; set; }
    public bool IsLovedTrack { get; set; }
    public bool Collaborative { get; set; }
    public int NbTracks { get; set; }
    public int Fans { get; set; }
    public string Link { get; set; }
    public string Share { get; set; }
    public string Picture { get; set; }
    public string PictureSmall { get; set; }
    public string PictureMedium { get; set; }
    public string PictureBig { get; set; }
    public string PictureXl { get; set; }
    public string Checksum { get; set; }
    public string Tracklist { get; set; }
    public DateTime CreationDate { get; set; }
    public string Md5Image { get; set; }
    public string PictureType { get; set; }
    public Creator Creator { get; set; }

    public string Description { get; set; }
}
