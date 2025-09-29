using System;
using System.Threading;

namespace Mindfulness
{
    public class Activity
    {
        protected int _duration;
        private DisplayStartingMessage _startingMessage = new DisplayStartingMessage();
        private DisplayEndingMessage _endingMessage = new DisplayEndingMessage();
        private ShowSpinner _spinner = new ShowSpinner();
        private ShowCountdown _countdown = new ShowCountdown();

        public Activity(int duration)
        {
            _duration = Math.Max(0, duration);
        }
        public void StartActivity()
        {
            _startingMessage.show();
            _spinner.show(3);
            Console.Clear();

            PerformActivity();

            _endingMessage.show(_duration);
            _spinner.show(3);
            Console.Clear();
        }
        public virtual void PerformActivity()
        {
            Console.WriteLine("Performing the activity...");
            _countdown.show(_duration);
        }
    }

    public class DisplayStartingMessage
    {
        public void show()
        {
            Console.WriteLine("Welcome to the Mindfulness Activity!");
            Console.WriteLine("This activity will help you relax and focus.");
            Console.WriteLine("Get ready to begin...");
            Console.WriteLine();
        }
    }

    public class DisplayEndingMessage
    {
        public void show(int duration)
        {
            Console.WriteLine("Congratulations on completing the activity!");
            Console.WriteLine($"You practiced mindfulness for {duration} seconds.");
        }
    }

    public class ShowSpinner
    {
        public void show(int seconds, string message = "Loading...")
        {
            char[] seq = { '|', '/', '-', '\\' };
            int delay = 1000;
            int totalSteps = (seconds * 1000) / delay;

            Console.Write(message);

            for (int i = 0; i < totalSteps; i++)
            {
                char spinnerChar = seq[i % seq.Length];

                Console.Write(spinnerChar);
                Thread.Sleep(delay);
                Console.Write('\b');
            }
            Console.Write(" ");
        }
    }

    public class ShowCountdown
    {
        public void show(int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}