using System;

namespace YouTubeVideos
{
    public class Comment
    {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public Comment(string user, string text)
        {
            User = user;
            Text = text;
            Timestamp = DateTime.Now;
        }

        public void Display()
        {
            Console.WriteLine($"[{Timestamp}] {User}: {Text}");
        }
    }
}