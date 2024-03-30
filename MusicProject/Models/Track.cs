namespace MusicProject.Models;

public class Track
{
    public int Id { get; set; }
    public bool Readable { get; set; }
    public string Title { get; set; }
    public string TitleShort { get; set; }
    public string TitleVersion { get; set; }
    public string Link { get; set; }
    public int Duration { get; set; }
    public int Rank { get; set; }
    public bool ExplicitLyrics { get; set; }
    public int ExplicitContentLyrics { get; set; }
    public int ExplicitContentCover { get; set; }
    public string Preview { get; set; }
    public string Md5Image { get; set; }
    public long TimeAdd { get; set; }
    public Artist Artist { get; set; }
    public Album Album { get; set; }
}
