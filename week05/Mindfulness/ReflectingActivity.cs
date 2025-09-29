using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new()
        {
            "Think of a time when you overcame a trial.",
            "Think of a time you have felt the Holy Ghost in your life.",
            "Think of one accomplishment that you are most pround of.",
            "Think of someone that you have helped.",
            "Think about the happiest moment of your life"
        };

        private List<string> _questions = new()
        {
            "Why was this experience meaningful to you?",
            "What did you learn about yourself from this experience?",
            "How can you apply what you learned to your life?",
            "What strengths did you display during this experience?",
            "How did this experience change your perspective?"
        };
        private Random _rand = new();
        private ShowSpinner _spinner = new();

        public ReflectingActivity(int duration) : base(duration) { }

        public void Run()
        {
            StartActivity();
        }

        public string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];

        public string GetRandomQuestion() => _questions[_rand.Next(_questions.Count)];

        public void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt: ");
            Console.WriteLine($"> {prompt}");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
        }

        public void DisplayQuestions()
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < _duration)
            {
                string question = GetRandomQuestion();
                Console.WriteLine($"> {question}");
                _spinner.show(5);
                Console.WriteLine();
            }
        }

        public override void PerformActivity()
        {
            DisplayPrompt();
            DisplayQuestions();
            Console.WriteLine("Well done! You have completed the Reflecting Activity!");
            ActivityLogger.Log("Reflecting", _duration);
        }
    }
}