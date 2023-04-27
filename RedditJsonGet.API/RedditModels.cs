namespace RedditJsonGet.API
{
    public class Rootobject
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public Children[] Children { get; set; }
    }

    public class Children
    {
        public ChildData Data { get; set; }
    }

    public class ChildData
    {
        public string Subreddit { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author_fullname { get; set; }
    }
}
