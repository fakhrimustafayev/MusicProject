using Newtonsoft.Json;

namespace MusicProject.Models
{

    public class SpotifyArtistResponse
    {
        public SpotArtist[] artists { get; set; }
    }

    public class SpotArtist
    {
        public SpotExternal_Urls external_urls { get; set; }
        public Followers followers { get; set; }
        public string[] genres { get; set; }
        public string id { get; set; }
        public SpotImage[] images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class SpotExternal_Urls
    {
        public string spotify { get; set; }
    }

    public class Followers
    {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class SpotImage
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }




    //public class TopArtist
    //{
    //    public int Rank { get; set; }
    //    public string Artist { get; set; }
    //    public double MonthlyListeners { get; set; }
    //}

}