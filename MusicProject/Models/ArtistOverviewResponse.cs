namespace MusicProject.Models
{

    public class ArtistOverviewResponse
    { 
        public OverData data { get; set; }
        public OverExtensions extensions { get; set; }
    }

    public class OverData
    {
        public OverArtist artist { get; set; }
    }

    public class OverArtist
    {
        public string id { get; set; }
        public string uri { get; set; }
        public bool following { get; set; }
        public Sharinginfo sharingInfo { get; set; }
        public Profile profile { get; set; }
        public Visuals visuals { get; set; }
        public Discography discography { get; set; }
        public Stats stats { get; set; }
        public Relatedcontent relatedContent { get; set; }
        public Goods goods { get; set; }
    }

    public class Sharinginfo
    {
        public string shareUrl { get; set; }
        public string shareId { get; set; }
    }

    public class Profile
    {
        public string name { get; set; }
        public bool verified { get; set; }
        public Pinneditem pinnedOverItem { get; set; }
        public Biography biography { get; set; }
        public Externallinks externalLinks { get; set; }
        public Playlists playlists { get; set; }
    }

    public class Pinneditem
    {
        public string comment { get; set; }
        public string type { get; set; }
        public OverItem item { get; set; }
    }

    public class OverItem
    {
        public string uri { get; set; }
        public string name { get; set; }
        public Coverart coverArt { get; set; }
        public string type { get; set; }
    }

    public class Coverart
    {
        public OverSource[] sources { get; set; }
    }

    public class OverSource
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Biography
    {
        public string text { get; set; }
    }

    public class Externallinks
    {
        public OverItem1[] items { get; set; }
    }

    public class OverItem1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Playlists
    {
        public int totalCount { get; set; }
        public OverItem2[] items { get; set; }
    }

    public class OverItem2
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Owner owner { get; set; }
        public OverImages images { get; set; }
    }

    public class Owner
    {
        public string name { get; set; }
    }

    public class OverImages
    {
        public OverItem3[] items { get; set; }
    }

    public class OverItem3
    {
        public OverSource1[] sources { get; set; }
    }

    public class OverSource1
    {
        public string url { get; set; }
        public object width { get; set; }
        public object height { get; set; }
    }

    public class Visuals
    {
        public Gallery gallery { get; set; }
        public Avatarimage avatarImage { get; set; }
        public Headerimage headerImage { get; set; }
    }

    public class Gallery
    {
        public OverItem4[] items { get; set; }
    }

    public class OverItem4
    {
        public OverSource2[] sources { get; set; }
    }

    public class OverSource2
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Avatarimage
    {
        public OverSource3[] sources { get; set; }
        public OverExtractedcolors extractedColors { get; set; }
    }

    public class OverExtractedcolors
    {
        public Colorraw colorRaw { get; set; }
    }

    public class Colorraw
    {
        public string hex { get; set; }
    }

    public class OverSource3
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Headerimage
    {
        public OverSource4[] sources { get; set; }
        public OverExtractedcolors1 extractedColors { get; set; }
    }

    public class OverExtractedcolors1
    {
        public Colorraw1 colorRaw { get; set; }
    }

    public class Colorraw1
    {
        public string hex { get; set; }
    }

    public class OverSource4
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Discography
    {
        public Latest latest { get; set; }
        public Popularreleases popularReleases { get; set; }
        public Singles singles { get; set; }
        public OverAlbums albums { get; set; }
        public Compilations compilations { get; set; }
        public Toptracks topTracks { get; set; }
    }

    public class Latest
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Copyright copyright { get; set; }
        public Date date { get; set; }
        public Coverart1 coverArt { get; set; }
        public OverTracks tracks { get; set; }
        public string label { get; set; }
        public Playability playability { get; set; }
    }

    public class Copyright
    {
        public OverItem5[] items { get; set; }
    }

    public class OverItem5
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Date
    {
        public int year { get; set; }
    }

    public class Coverart1
    {
        public OverSource5[] sources { get; set; }
    }

    public class OverSource5
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OverTracks
    {
        public int totalCount { get; set; }
    }

    public class Playability
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Popularreleases
    {
        public int totalCount { get; set; }
        public OverItem6[] items { get; set; }
    }

    public class OverItem6
    {
        public Releases releases { get; set; }
    }

    public class Releases
    {
        public OverItem7[] items { get; set; }
    }

    public class OverItem7
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Copyright1 copyright { get; set; }
        public Date1 date { get; set; }
        public Coverart2 coverArt { get; set; }
        public OverTracks1 tracks { get; set; }
        public string label { get; set; }
        public Playability1 playability { get; set; }
        public Sharinginfo1 sharingInfo { get; set; }
    }

    public class Copyright1
    {
        public OverItem8[] items { get; set; }
    }

    public class OverItem8
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Date1
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string precision { get; set; }
    }

    public class Coverart2
    {
        public OverSource6[] sources { get; set; }
    }

    public class OverSource6
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OverTracks1
    {
        public int totalCount { get; set; }
    }

    public class Playability1
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Sharinginfo1
    {
        public string shareId { get; set; }
        public string shareUrl { get; set; }
    }

    public class Singles
    {
        public int totalCount { get; set; }
        public OverItem9[] items { get; set; }
    }

    public class OverItem9
    {
        public Releases1 releases { get; set; }
    }

    public class Releases1
    {
        public OverItem10[] items { get; set; }
    }

    public class OverItem10
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Copyright2 copyright { get; set; }
        public Date2 date { get; set; }
        public Coverart3 coverArt { get; set; }
        public OverTracks2 tracks { get; set; }
        public string label { get; set; }
        public Playability2 playability { get; set; }
        public Sharinginfo2 sharingInfo { get; set; }
    }

    public class Copyright2
    {
        public OverItem11[] items { get; set; }
    }

    public class OverItem11
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Date2
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string precision { get; set; }
    }

    public class Coverart3
    {
        public OverSource7[] sources { get; set; }
    }

    public class OverSource7
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OverTracks2
    {
        public int totalCount { get; set; }
    }

    public class Playability2
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Sharinginfo2
    {
        public string shareId { get; set; }
        public string shareUrl { get; set; }
    }

    public class OverAlbums
    {
        public int totalCount { get; set; }
        public OverItem12[] items { get; set; }
    }

    public class OverItem12
    {
        public Releases2 releases { get; set; }
    }

    public class Releases2
    {
        public OverItem13[] items { get; set; }
    }

    public class OverItem13
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Copyright3 copyright { get; set; }
        public Date3 date { get; set; }
        public Coverart4 coverArt { get; set; }
        public OverTracks3 tracks { get; set; }
        public string label { get; set; }
        public Playability3 playability { get; set; }
        public Sharinginfo3 sharingInfo { get; set; }
    }

    public class Copyright3
    {
        public OverItem14[] items { get; set; }
    }

    public class OverItem14
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Date3
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string precision { get; set; }
    }

    public class Coverart4
    {
        public OverSource8[] sources { get; set; }
    }

    public class OverSource8
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OverTracks3
    {
        public int totalCount { get; set; }
    }

    public class Playability3
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Sharinginfo3
    {
        public string shareId { get; set; }
        public string shareUrl { get; set; }
    }

    public class Compilations
    {
        public int totalCount { get; set; }
        public OverItem15[] items { get; set; }
    }

    public class OverItem15
    {
        public Releases3 releases { get; set; }
    }

    public class Releases3
    {
        public OverItem16[] items { get; set; }
    }

    public class OverItem16
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Copyright4 copyright { get; set; }
        public Date4 date { get; set; }
        public Coverart5 coverArt { get; set; }
        public OverTracks4 tracks { get; set; }
        public string label { get; set; }
        public Playability4 playability { get; set; }
        public Sharinginfo4 sharingInfo { get; set; }
    }

    public class Copyright4
    {
        public OverItem17[] items { get; set; }
    }

    public class OverItem17
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Date4
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public string precision { get; set; }
    }

    public class Coverart5
    {
        public OverSource9[] sources { get; set; }
    }

    public class OverSource9
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class OverTracks4
    {
        public int totalCount { get; set; }
    }

    public class Playability4
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Sharinginfo4
    {
        public string shareId { get; set; }
        public string shareUrl { get; set; }
    }

    public class Toptracks
    {
        public OverItem18[] items { get; set; }
    }

    public class OverItem18
    {
        public string uid { get; set; }
        public OverTrack track { get; set; }
    }

    public class OverTrack
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public string playcount { get; set; }
        public int discNumber { get; set; }
        public Duration duration { get; set; }
        public Playability5 playability { get; set; }
        public Contentrating contentRating { get; set; }
        public OverArtists artists { get; set; }
        public OverAlbum album { get; set; }
    }

    public class Duration
    {
        public int totalMilliseconds { get; set; }
    }

    public class Playability5
    {
        public bool playable { get; set; }
        public string reason { get; set; }
    }

    public class Contentrating
    {
        public string label { get; set; }
    }

    public class OverArtists
    {
        public OverItem19[] items { get; set; }
    }

    public class OverItem19
    {
        public string uri { get; set; }
        public Profile1 profile { get; set; }
    }

    public class Profile1
    {
        public string name { get; set; }
    }

    public class OverAlbum
    {
        public string uri { get; set; }
        public Coverart6 coverArt { get; set; }
    }

    public class Coverart6
    {
        public OverSource10[] sources { get; set; }
    }

    public class OverSource10
    {
        public string url { get; set; }
    }

    public class Stats
    {
        public int followers { get; set; }
        public int monthlyListeners { get; set; }
        public int worldRank { get; set; }
        public Topcities topCities { get; set; }
    }

    public class Topcities
    {
        public OverItem20[] items { get; set; }
    }

    public class OverItem20
    {
        public int numberOfListeners { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class Relatedcontent
    {
        public Appearson appearsOn { get; set; }
        public Featuring featuring { get; set; }
        public Discoveredon discoveredOn { get; set; }
        public Relatedartists relatedOverArtists { get; set; }
    }

    public class Appearson
    {
        public int totalCount { get; set; }
        public OverItem21[] items { get; set; }
    }

    public class OverItem21
    {
        public Releases4 releases { get; set; }
    }

    public class Releases4
    {
        public int totalCount { get; set; }
        public OverItem22[] items { get; set; }
    }

    public class OverItem22
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public OverArtists1 artists { get; set; }
        public Coverart7 coverArt { get; set; }
        public Date5 date { get; set; }
        public Sharinginfo5 sharingInfo { get; set; }
    }

    public class OverArtists1
    {
        public OverItem23[] items { get; set; }
    }

    public class OverItem23
    {
        public string uri { get; set; }
        public Profile2 profile { get; set; }
    }

    public class Profile2
    {
        public string name { get; set; }
    }

    public class Coverart7
    {
        public OverSource11[] sources { get; set; }
    }

    public class OverSource11
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Date5
    {
        public int year { get; set; }
    }

    public class Sharinginfo5
    {
        public string shareId { get; set; }
        public string shareUrl { get; set; }
    }

    public class Featuring
    {
        public int totalCount { get; set; }
        public OverItem24[] items { get; set; }
    }

    public class OverItem24
    {
        public string uri { get; set; }
        public string id { get; set; }
        public Owner1 owner { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public OverImages1 images { get; set; }
    }

    public class Owner1
    {
        public string name { get; set; }
    }

    public class OverImages1
    {
        public int totalCount { get; set; }
        public OverItem25[] items { get; set; }
    }

    public class OverItem25
    {
        public OverSource12[] sources { get; set; }
    }

    public class OverSource12
    {
        public string url { get; set; }
        public object width { get; set; }
        public object height { get; set; }
    }

    public class Discoveredon
    {
        public int totalCount { get; set; }
        public OverItem26[] items { get; set; }
    }

    public class OverItem26
    {
        public string uri { get; set; }
        public string id { get; set; }
        public Owner2 owner { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public OverImages2 images { get; set; }
    }

    public class Owner2
    {
        public string name { get; set; }
    }

    public class OverImages2
    {
        public int totalCount { get; set; }
        public OverItem27[] items { get; set; }
    }

    public class OverItem27
    {
        public OverSource13[] sources { get; set; }
    }

    public class OverSource13
    {
        public string url { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class Relatedartists
    {
        public int totalCount { get; set; }
        public OverItem28[] items { get; set; }
    }

    public class OverItem28
    {
        public string id { get; set; }
        public string uri { get; set; }
        public Profile3 profile { get; set; }
        public Visuals1 visuals { get; set; }
    }

    public class Profile3
    {
        public string name { get; set; }
    }

    public class Visuals1
    {
        public Avatarimage1 avatarImage { get; set; }
    }

    public class Avatarimage1
    {
        public OverSource14[] sources { get; set; }
    }

    public class OverSource14
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Goods
    {
        public Events events { get; set; }
        public Merch merch { get; set; }
    }

    public class Events
    {
        public Userlocation userLocation { get; set; }
        public Concerts concerts { get; set; }
    }

    public class Userlocation
    {
        public string name { get; set; }
    }

    public class Concerts
    {
        public int totalCount { get; set; }
        public OverItem29[] items { get; set; }
        public Paginginfo pagingInfo { get; set; }
    }

    public class Paginginfo
    {
        public int limit { get; set; }
    }

    public class OverItem29
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public bool festival { get; set; }
        public bool nearUser { get; set; }
        public Venue venue { get; set; }
        public OverArtists2 artists { get; set; }
        public Partnerlinks partnerLinks { get; set; }
        public Date6 date { get; set; }
    }

    public class Venue
    {
        public string name { get; set; }
        public Location location { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
    }

    public class Coordinates
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class OverArtists2
    {
        public OverItem30[] items { get; set; }
    }

    public class OverItem30
    {
        public string uri { get; set; }
        public string id { get; set; }
        public Profile4 profile { get; set; }
    }

    public class Profile4
    {
        public string name { get; set; }
    }

    public class Partnerlinks
    {
        public OverItem31[] items { get; set; }
    }

    public class OverItem31
    {
        public string partnerName { get; set; }
        public string url { get; set; }
    }

    public class Date6
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
        public string isoString { get; set; }
        public string precision { get; set; }
    }

    public class Merch
    {
        public OverItem32[] items { get; set; }
    }

    public class OverItem32
    {
        public string uri { get; set; }
        public string description { get; set; }
        public string imageUri { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class OverExtensions
    {
    }


    // Add more classes as needed for the complete response structure

}
