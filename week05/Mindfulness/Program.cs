using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the Mindfulness Project.");

            int totalDuration = 0;
            Dictionary<string, int> activityCount = new();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose an Activity:");
                Console.WriteLine("1. Listing");
                Console.WriteLine("2. Reflecting");
                Console.WriteLine("3. Breathing");
                Console.WriteLine("4. Quit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                if (choice == "4" || choice?.ToLower() == "quit") break;

                Console.Write("Enter duration in seconds (default 30): ");
                if (!int.TryParse(Console.ReadLine(), out int duration)) duration = 30;

                switch (choice)
                {
                    case "1":
                        new ListingActivity(duration).Run();
                        totalDuration += duration;
                        if (!activityCount.ContainsKey("Listing")) activityCount["Listing"] = 0;
                        activityCount["Listing"]++;
                        break;
                    case "2":
                        new ReflectingActivity(duration).Run();
                        totalDuration += duration;
                        if (!activityCount.ContainsKey("Reflecting")) activityCount["Reflecting"] = 0;
                        activityCount["Reflecting"]++;
                        break;
                    case "3":
                        new BreathingActivity(duration).Run();
                        totalDuration += duration;
                        if (!activityCount.ContainsKey("Breathing")) activityCount["Breathing"] = 0;
                        activityCount["Breathing"]++;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("\n--- Session Summary ---");
                Console.WriteLine($"Total time spent: {totalDuration} seconds");
                foreach (var pair in activityCount)
                {
                    Console.WriteLine($"- {pair.Key} activities: {pair.Value}");
                }
            }
            Console.WriteLine("Thank you for doing these activities!");
        }
    }
}