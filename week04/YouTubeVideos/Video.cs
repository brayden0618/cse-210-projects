using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public string Author { get; set; }

        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string description, int duration, string author = "Brayden")
        {
            Title = title;
            Description = description;
            Duration = duration;
            Author = author;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }

        public void Play()
        {
            Console.WriteLine($"Playing video: {Title} by {Author}");
        }

        public void Pause()
        {
            Console.WriteLine($"Pausing video: {Title} by {Author}");
        }

        public void Stop()
        {
            Console.WriteLine($"Stopping video: {Title} by {Author}");
        }
    }
}