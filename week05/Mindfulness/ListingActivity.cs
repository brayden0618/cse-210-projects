using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new()
        {
            "List all the ways you have been blessed throughout your life.",
            "List people who have helped you recently.",
            "List activities that bring you joy.",
            "List ways that you have helped people.",
            "List Temples you have been to."
        };

        private Random _rand = new();
        private ShowCountdown _countdown = new();

        public ListingActivity(int duration) : base(duration) { }

        public void Run()
        {
            StartActivity();
        }

        public string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];

        public List<string> GetListFromUser()
        {
            var items = new List<string>();
            Console.WriteLine($"You will have {_duration} seconds to list as many responses as you can.");
            Console.WriteLine("When ready, press Enter to begin.");
            Console.ReadLine();

            _countdown.show(3);
            Console.WriteLine("Start Listing! Press Enter after each item.");

            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < _duration)
            {
                if (Console.KeyAvailable)
                {
                    string line = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        items.Add(line.Trim());
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            return items;
        }

        public override void PerformActivity()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"> {prompt}");
            Console.WriteLine();

            var responses = GetListFromUser();

            Console.WriteLine();
            Console.WriteLine($"You listed {responses.Count} items:");
            foreach (var r in responses)
            {
                Console.WriteLine($"- {r}");
            }
            Console.WriteLine("Well done! You have completed the Listing Activity!");
            ActivityLogger.Log("Listing", _duration, responses);
        }
    }
}