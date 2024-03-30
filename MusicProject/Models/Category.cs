namespace MusicProject.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Track> Tracks { get; set; } = null!;
}
