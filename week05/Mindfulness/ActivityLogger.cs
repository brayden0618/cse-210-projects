using System;
using System.Collections.Generic;
using System.IO;

namespace Mindfulness
{
    public static class ActivityLogger
    {
        private static readonly string logFile = "activity_log.txt";

        public static void Log(string activityName, int duration, List<string> responses = null)
        {
            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine($"[{DateTime.Now}] {activityName} Activity (Duration: {duration}s)");

                if (responses != null && responses.Count > 0)
                {
                    foreach (var response in responses)
                    {
                        writer.WriteLine($"- {response}");
                    }
                }

                writer.WriteLine(); 
            }
        }
    }
}