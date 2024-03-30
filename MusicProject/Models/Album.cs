using System.ComponentModel.DataAnnotations;

namespace MusicProject.Models;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Cover { get; set; }
    public string CoverSmall { get; set; }
    public string CoverMedium { get; set; }
    public string CoverBig { get; set; }
    public string CoverXl { get; set; }
    public string Md5Image { get; set; }
    public string Tracklist { get; set; }
    public string Type { get; set; }


}
