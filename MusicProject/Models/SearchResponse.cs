namespace MusicProject.Models
{


    public class SearchResponse
    {
        public Albums albums { get; set; }
        public Artists1 artists { get; set; }
        public Episodes episodes { get; set; }
        public Genres genres { get; set; }
        public SearchPlaylists playlists { get; set; }
        public Podcasts podcasts { get; set; }
        public Topresults topResults { get; set; }
        public SearchTracks tracks { get; set; }
        public Users users { get; set; }
    }

    public class Albums
    {
        public int totalCount { get; set; }
        public SearchItem[] items { get; set; }
    }

    public class SearchItem
    {
        public SearchData data { get; set; }
    }

    public class SearchData
    {
        public string uri { get; set; }
        public string name { get; set; }
        public Artists artists { get; set; }
        public SearchCoverart coverArt { get; set; }
        public SearchDate date { get; set; }
    }

    public class Artists
    {
        public SearchItem1[] items { get; set; }
    }

    public class SearchItem1
    {
        public string uri { get; set; }
        public SearchProfile profile { get; set; }
    }

    public class SearchProfile
    {
        public string name { get; set; }
    }

    public class SearchCoverart
    {
        public SearchSource[] sources { get; set; }
    }

    public class SearchSource
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class SearchDate
    {
        public int year { get; set; }
    }

    public class Artists1
    {
        public int totalCount { get; set; }
        public SearchItem2[] items { get; set; }
    }

    public class SearchItem2
    {
        public SearchData1 data { get; set; }
    }

    public class SearchData1
    {
        public string uri { get; set; }
        public SearchProfile1 profile { get; set; }
        public SearchVisuals visuals { get; set; }
    }

    public class SearchProfile1
    {
        public string name { get; set; }
    }

    public class SearchVisuals
    {
        public SearchAvatarimage avatarImage { get; set; }
    }

    public class SearchAvatarimage
    {
        public Source1[] sources { get; set; }
    }

    public class Source1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Episodes
    {
        public int totalCount { get; set; }
        public Item3[] items { get; set; }
    }

    public class Item3
    {
        public SearchData2 data { get; set; }
    }

    public class SearchData2
    {
        public string uri { get; set; }
        public string name { get; set; }
        public SearchCoverart1 coverArt { get; set; }
        public SearchDuration duration { get; set; }
        public Releasedate releaseDate { get; set; }
        public Podcast podcast { get; set; }
        public string description { get; set; }
        public SearchContentrating contentRating { get; set; }
    }

    public class SearchCoverart1
    {
        public Source2[] sources { get; set; }
    }

    public class Source2
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class SearchDuration
    {
        public int totalMilliseconds { get; set; }
    }

    public class Releasedate
    {
        public DateTime isoString { get; set; }
    }

    public class Podcast
    {
        public SearchCoverart2 coverArt { get; set; }
    }

    public class SearchCoverart2
    {
        public Source3[] sources { get; set; }
    }

    public class Source3
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class SearchContentrating
    {
        public string label { get; set; }
    }

    public class Genres
    {
        public int totalCount { get; set; }
        public object[] items { get; set; }
    }

    public class SearchPlaylists
    {
        public int totalCount { get; set; }
        public List<Item4> items { get; set; } // Change to List<SearchData3>
    }


    public class Item4
    {
        public SearchData3 data { get; set; }
    }

    public class SearchData3
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public SearchImages images { get; set; }
        public SearchOwner owner { get; set; }
    }

    public class SearchImages
    {
        public Item5[] items { get; set; }
    }

    public class Item5
    {
        public Source4[] sources { get; set; }
    }

    public class Source4
    {
        public string url { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class SearchOwner
    {
        public string name { get; set; }
    }

    public class Podcasts
    {
        public int totalCount { get; set; }
        public Item6[] items { get; set; }
    }

    public class Item6
    {
        public Data4 data { get; set; }
    }

    public class Data4
    {
        public string uri { get; set; }
        public string name { get; set; }
        public SearchCoverart3 coverArt { get; set; }
        public string type { get; set; }
        public Publisher publisher { get; set; }
        public string mediaType { get; set; }
    }

    public class SearchCoverart3
    {
        public Source5[] sources { get; set; }
    }

    public class Source5
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Publisher
    {
        public string name { get; set; }
    }

    public class Topresults
    {
        public Item7[] items { get; set; }
        public Featured[] featured { get; set; }
    }

    public class Item7
    {
        public Data5 data { get; set; }
    }

    public class Data5
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Albumoftrack albumOfTrack { get; set; }
        public Artists2 artists { get; set; }
        public Contentrating1 contentRating { get; set; }
        public Duration1 duration { get; set; }
        public SearchPlayability playability { get; set; }
        public SearchProfile3 profile { get; set; }
        public SearchVisuals1 visuals { get; set; }
        public string description { get; set; }
        public Images1 images { get; set; }
        public SearchOwner1 owner { get; set; }
    }

    public class Albumoftrack
    {
        public string uri { get; set; }
        public string name { get; set; }
        public SearchCoverart4 coverArt { get; set; }
        public string id { get; set; }
        public SearchSharinginfo sharingInfo { get; set; }
    }

    public class SearchCoverart4
    {
        public Source6[] sources { get; set; }
    }

    public class Source6
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class SearchSharinginfo
    {
        public string shareUrl { get; set; }
    }

    public class Artists2
    {
        public Item8[] items { get; set; }
    }

    public class Item8
    {
        public string uri { get; set; }
        public SearchProfile2 profile { get; set; }
    }

    public class SearchProfile2
    {
        public string name { get; set; }
    }

    public class Contentrating1
    {
        public string label { get; set; }
    }

    public class Duration1
    {
        public int totalMilliseconds { get; set; }
    }

    public class SearchPlayability
    {
        public bool playable { get; set; }
    }

    public class SearchProfile3
    {
        public string name { get; set; }
    }

    public class SearchVisuals1
    {
        public SearchAvatarimage1 avatarImage { get; set; }
    }

    public class SearchAvatarimage1
    {
        public Source7[] sources { get; set; }
    }

    public class Source7
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Images1
    {
        public Item9[] items { get; set; }
    }

    public class Item9
    {
        public Source8[] sources { get; set; }
    }

    public class Source8
    {
        public string url { get; set; }
        public object width { get; set; }
        public object height { get; set; }
    }

    public class SearchOwner1
    {
        public string name { get; set; }
    }

    public class Featured
    {
        public Data6 data { get; set; }
    }

    public class Data6
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Images2 images { get; set; }
        public SearchOwner2 owner { get; set; }
    }

    public class Images2
    {
        public Item10[] items { get; set; }
    }

    public class Item10
    {
        public Source9[] sources { get; set; }
    }

    public class Source9
    {
        public string url { get; set; }
        public object width { get; set; }
        public object height { get; set; }
    }

    public class SearchOwner2
    {
        public string name { get; set; }
    }

    public class SearchTracks
    {
        public int totalCount { get; set; }
        public Item11[] items { get; set; }
    }

    public class Item11
    {
        public Data7 data { get; set; }
    }

    public class Data7
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Albumoftrack1 albumOfTrack { get; set; }
        public Artists3 artists { get; set; }
        public Contentrating2 contentRating { get; set; }
        public Duration2 duration { get; set; }
        public Playability1 playability { get; set; }
    }

    public class Albumoftrack1
    {
        public string uri { get; set; }
        public string name { get; set; }
        public SearchCoverart5 coverArt { get; set; }
        public string id { get; set; }
        public SearchSharinginfo1 sharingInfo { get; set; }
    }

    public class SearchCoverart5
    {
        public Source10[] sources { get; set; }
    }

    public class Source10
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class SearchSharinginfo1
    {
        public string shareUrl { get; set; }
    }

    public class Artists3
    {
        public Item12[] items { get; set; }
    }

    public class Item12
    {
        public string uri { get; set; }
        public SearchProfile4 profile { get; set; }
    }

    public class SearchProfile4
    {
        public string name { get; set; }
    }

    public class Contentrating2
    {
        public string label { get; set; }
    }

    public class Duration2
    {
        public int totalMilliseconds { get; set; }
    }

    public class SearchPlayability1
    {
        public bool playable { get; set; }
    }

    public class Users
    {
        public int totalCount { get; set; }
        public Item13[] items { get; set; }
    }

    public class Item13
    {
        public Data8 data { get; set; }
    }

    public class Data8
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string displayName { get; set; }
        public string username { get; set; }
        public SearchImage image { get; set; }
    }

    public class SearchImage
    {
        public string smallImageUrl { get; set; }
        public string largeImageUrl { get; set; }
    }


}

