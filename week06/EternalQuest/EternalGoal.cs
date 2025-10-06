using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
        }

        public override bool IsComplete => false;

        public override int RecordEvent()
        {
            return _points;
        }

        public override string GetStatusString()
        {
            return "[∞] ";
        }

        public override string ToCsv()
        {
            return $"Eternal|{_title}|{_description}|{_points}";
        }
    }
}