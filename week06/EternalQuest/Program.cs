using System;
using System.Collections.Generic;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var goalManager = new GoalManager();

            while (true)
            {
                Console.WriteLine("Hello World this is the Eternal Quest Project.");
                Console.WriteLine();
                Console.WriteLine($"Score: {goalManager.GetScore()}");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                var choice = Console.ReadLine()?.Trim();
                if (choice == "6" || choice?.ToLower() == "quit") break;

                if (choice == "1")
                {
                    Console.Write("Type of goal (Simple, Eternal, Checklist): ");
                    var type = Console.ReadLine()?.ToLower();
                    Console.Write("Enter the name of the goal: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter a short description of the goal: ");
                    var desc = Console.ReadLine();
                    Console.Write("Enter the points associated with this goal: ");
                    int.TryParse(Console.ReadLine(), out int points);

                    if (type == "simple")
                    {
                        goalManager.AddGoal(new SimpleGoal(name, desc, points));
                    }
                    else if (type == "eternal")
                    {
                        goalManager.AddGoal(new EternalGoal(name, desc, points));
                    }
                    else if (type == "checklist")
                    {
                        Console.Write("Enter the target number of completions: ");
                        int.TryParse(Console.ReadLine(), out int target);
                        Console.Write("Enter the bonus points for completing the checklist: ");
                        int.TryParse(Console.ReadLine(), out int bonus);
                        goalManager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("The goals are:");
                    for (int i = 0; i < goalManager.Goals.Count; i++)
                    {
                        var goal = goalManager.Goals[i];
                        Console.WriteLine($"{i + 1}. {goal.GetStatusString()}{goal.Title} ({goal.Description})");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter the filename to save goals: ");
                    var filename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        goalManager.SaveToFile(filename);
                        Console.WriteLine("Goals saved.");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Enter the filename to load goals: ");
                    var filename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(filename))
                    {
                        try
                        {
                            goalManager.LoadFromFile(filename);
                            Console.WriteLine("Goals loaded.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error loading goals: {ex.Message}");
                        }
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Select a goal to record an event:");
                    for (int i = 0; i < goalManager.Goals.Count; i++)
                    {
                        var goal = goalManager.Goals[i];
                        Console.WriteLine($"{i + 1}. {goal.GetStatusString()}{goal.Title} ({goal.Description})");
                    }
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goalManager.Goals.Count)
                    {
                        int prevLevel = goalManager.GetLevel();
                        int pointsEarned = goalManager.RecordGoal(index - 1);
                        int newLevel = goalManager.GetLevel();

                        Console.WriteLine(pointsEarned > 0
                            ? $"Congratulations! You earned {pointsEarned} points."
                            : "This goal is already complete or no points earned.");
                        
                        if (newLevel > prevLevel)
                        {
                            Console.WriteLine($"Level Up! You are now level {newLevel}.");
                        }
                        else
                        {
                            int toNext = goalManager.GetPointsToNextLevel();
                            double percent = goalManager.GetProgressToNextLevelPercent();
                            Console.WriteLine($"You need {toNext} more points to reach the next level ({percent:F1}% there).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}