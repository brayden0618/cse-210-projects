using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _currentCount;
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonusPoints)
            : base(shortName, description, points)
        {
            _currentCount = 0;
            _targetCount = Math.Max(1, targetCount);
            _bonusPoints = Math.Max(0, bonusPoints);
        }

        public override bool IsComplete => _currentCount >= _targetCount;

        public override int RecordEvent()
        {
            if (IsComplete) return 0;

            _currentCount++;
            if (IsComplete)
            {
                return _points + _bonusPoints;
            }
            return _points;
        }

        public override string GetStatusString()
        {
            return $"[{_currentCount}/{_targetCount}] ";
        }

        public override string ToCsv()
        {
            return $"Checklist|{_title}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }

        internal void ForceSetCurrent(int value)
        {
            _currentCount = Math.Max(value, 0);
        }
    }
}