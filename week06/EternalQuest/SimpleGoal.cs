using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
            _completed = false;
        }

        public override bool IsComplete => _completed;

        public override int RecordEvent()
        {
            if (_completed) return 0;
            _completed = true;
            return _points;
        }

        public override string GetStatusString()
        {
            return _completed ? "[X] " : "[ ] ";
        }

        public override string ToCsv()
        {
            return $"Simple|{_title}|{_description}|{_points}|{_completed}";
        }

        internal void ForceComplete()
        {
            _completed = true;
        }
    }
}