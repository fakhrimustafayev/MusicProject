

using System.ComponentModel.DataAnnotations.Schema;

namespace MusicProject.Models
{ 
public class GetNewReleaseResult
{
    public Albums albums { get; set; }
}

public class Albums
{
    public string href { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
    public Item[] items { get; set; }
}

public class Item
{
    public string album_type { get; set; }
    public int total_tracks { get; set; }
    public string[] available_markets { get; set; }
    public External_Urls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public Image[] images { get; set; }
    public string name { get; set; }
    public string release_date { get; set; }
    public string release_date_precision { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public Singer[] artists { get; set; }
}

    
public class External_Urls
{
        
    public string spotify { get; set; }
}

public class Image
{
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}

public class Singer
{
        [NotMapped]

        public External_Urls1 external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class External_Urls1
{
      
    public string spotify { get; set; }
}
}

