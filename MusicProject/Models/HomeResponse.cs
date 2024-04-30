namespace MusicProject.Models
{

    public class HomeResponse
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
        public bool error { get; set; }
    }

    public class Data
    {
        public Home home { get; set; }
    }

    public class Home
    {
        public string __typename { get; set; }
        public Greeting greeting { get; set; }
        public Sectioncontainer sectionContainer { get; set; }
    }

    public class Greeting
    {
        public string text { get; set; }
    }

    public class Sectioncontainer
    {
        public string uri { get; set; }
        public Sections sections { get; set; }
    }

    public class Sections
    {
        public Item[] items { get; set; }
        public int totalCount { get; set; }
    }

    public class Item
    {
        public string uri { get; set; }
        public Data1 data { get; set; }
        public Sectionitems sectionItems { get; set; }
    }

    public class Data1
    {
        public string __typename { get; set; }
        public Title title { get; set; }
    }

    public class Title
    {
        public string text { get; set; }
    }

    public class Sectionitems
    {
        public Item1[] items { get; set; }
        public int totalCount { get; set; }
    }

    public class Item1
    {
        public string uri { get; set; }
        public Content content { get; set; }
        public object data { get; set; }
    }

    public class Content
    {
        public string __typename { get; set; }
        public Data2 data { get; set; }
    }

    public class Data2
    {
        public string __typename { get; set; }
        public string uri { get; set; }
        public string name { get; set; }
        public Images images { get; set; }
        public string description { get; set; }
        public Ownerv2 ownerV2 { get; set; }
    }

    public class Images
    {
        public Item2[] items { get; set; }
    }

    public class Item2
    {
        public Source[] sources { get; set; }
        public Extractedcolors extractedColors { get; set; }
    }

    public class Extractedcolors
    {
        public Colordark colorDark { get; set; }
    }

    public class Colordark
    {
        public string hex { get; set; }
        public bool isFallback { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public object width { get; set; }
        public object height { get; set; }
    }

    public class Ownerv2
    {
        public Data3 data { get; set; }
    }

    public class Data3
    {
        public string __typename { get; set; }
        public string name { get; set; }
    }

    public class Extensions
    {
    }

}
