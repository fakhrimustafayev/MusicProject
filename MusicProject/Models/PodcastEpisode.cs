namespace MusicProject.Models
{
    public class PodcastEpisode
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShareUrl { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string HtmlDescription { get; set; }
        public long DurationMs { get; set; }
        public string DurationText { get; set; }
        public bool PaywallContent { get; set; }
        public Audio Audio { get; set; }
        public List<CoverImage> CoverImages { get; set; }
        public PodcastDetails Podcast { get; set; }
    }

    public class Audio
    {
        public string Url { get; set; }
        public string PreviewUrl { get; set; }
    }

    public class CoverImage
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class PodcastDetails
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShareUrl { get; set; }
        public List<CoverImage> CoverImages { get; set; }
    }

    public class EpisodeResponse
    {
        public bool Status { get; set; }
        public EpisodeData Episodes { get; set; }
    }

    public class EpisodeData
    {
        public int TotalCount { get; set; }
        public List<PodcastEpisode> Items { get; set; }
    }

}
