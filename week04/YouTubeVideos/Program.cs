using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

            List<Video> videos = new List<Video>();

            // Video 1
            Video video1 = new Video("C# Tutorial", "Learn the basics of C#", 600);
            video1.AddComment(new Comment("HALO237", "First Comment!"));
            video1.AddComment(new Comment("Mr.X111", "Very helpful, thanks!"));
            video1.AddComment(new Comment("NiceBro", "Can you make a video on advanced topics?"));
            videos.Add(video1);

            // Video 2
            Video video2 = new Video("My first video", "Description of my first video", 900);
            video2.AddComment(new Comment("UserA777", "This was exactly what I needed."));
            video2.AddComment(new Comment("GamerBoy999", "Thanks for the clear explanation!"));
            video2.AddComment(new Comment("SuperBat", "Looking forward to more videos on this topic."));
            videos.Add(video2);

            // Video 3
            Video video3 = new Video("Funny Cat Videos", "Compilation of funny cat videos", 750);
            video3.AddComment(new Comment("Dev123", "These cats are hilarious!"));
            video3.AddComment(new Comment("Spongeboy678", "I can't stop watching this."));
            video3.AddComment(new Comment("Gambino999", "More cat videos, please!"));
            videos.Add(video3);

            // Video Info Display
            foreach (Video video in videos)
            {
                Console.WriteLine($"\nTitle: {video.Title}");
                Console.WriteLine($"Description: {video.Description}");
                Console.WriteLine($"Duration: {video.Duration} seconds");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- [{comment.Timestamp}] {comment.User}: {comment.Text}");
                }

                Console.WriteLine(); // Blank line for better readability
            }
            Console.WriteLine("End of YouTubeVideos Project.");
        }
    }
}