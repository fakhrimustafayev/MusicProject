namespace MusicProject.Models
{

    public class GenreViewResponse
    {
        public GenreContent content { get; set; }
        public object[] custom_fields { get; set; }
        public object external_urls { get; set; }
        public string id { get; set; }
        public object name { get; set; }
        public string rendering { get; set; }
        public object tag_line { get; set; }
        public string type { get; set; }
    }

    public class GenreContent
    {
        public GenreItem[] items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class GenreItem
    {
        public Content1 content { get; set; }
        public object[] custom_fields { get; set; }
        public object external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string rendering { get; set; }
        public object tag_line { get; set; }
        public string type { get; set; }
    }

    public class Content1
    {
        public GenreItem1[] items { get; set; }
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class GenreItem1
    {
        public bool collaborative { get; set; }
        public string description { get; set; }
        public GenreExternalUrls external_urls { get; set; }
        public string id { get; set; }
        public GenreImage[] images { get; set; }
        public string name { get; set; }
        public GenreOwner owner { get; set; }
        public object primary_color { get; set; }
        public object _public { get; set; }
        public string snapshot_id { get; set; }
        public Tracks tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class GenreExternalUrls
    {
        public string spotify { get; set; }
    }

    public class GenreOwner
    {
        public string display_name { get; set; }
        public GenreExternalUrls1 external_urls { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class GenreExternalUrls1
    {
        public string spotify { get; set; }
    }

    public class Tracks
    {
        public int total { get; set; }
    }

    public class GenreImage
    {
        public int? height { get; set; }
        public string url { get; set; }
        public int? width { get; set; }
    }


}
