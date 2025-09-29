using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        private ShowCountdown _countdown = new ShowCountdown();
        public BreathingActivity(int duration) : base(duration) {}
        public void Run()
        {
            StartActivity();
        }
        public override void PerformActivity()
        {
            Console.WriteLine("This is the Breathing Activity.");
            Console.WriteLine("Follow the prompts to breathe in and out.");
            Console.WriteLine();

            int halfDuration = _duration / 2;

            for (int i = 0; i < _duration / 4; i++)
            {
                Console.Write("Breathe in... ");
                _countdown.show(halfDuration);
                Console.WriteLine();

                Console.Write("Breathe out... ");
                _countdown.show(halfDuration);
                Console.WriteLine();
            }
            Console.WriteLine("Well done! You have Completed the Breathing Activity!");
            ActivityLogger.Log("Breathing", _duration);
        }
    }
}