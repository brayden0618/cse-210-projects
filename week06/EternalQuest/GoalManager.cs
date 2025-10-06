using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        private const int PointsPerLevel = 1000;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void AddGoal(Goal goal) => _goals.Add(goal);

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

        public int GetScore() => _score;

        public int GetLevel() => _score / PointsPerLevel + 1;
        public int GetPointsToNextLevel() => PointsPerLevel - (_score % PointsPerLevel);
        public double GetProgressToNextLevelPercent() => (_score % PointsPerLevel) / (double)PointsPerLevel * 100.0;

        public int RecordGoal(int index)
        {
            if (index < 0 || index >= _goals.Count) throw new ArgumentOutOfRangeException(nameof(index));
            var g = _goals[index];
            int pointsEarned = g.RecordEvent();
            _score += pointsEarned;
            return pointsEarned;
        }

        public void SaveToFile(string filename)
        {
            using var writer = new StreamWriter(filename);
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.ToCsv());
            }
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);

            var lines = File.ReadAllLines(filename);
            _goals.Clear();
            if (lines.Length == 0) return;

            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                var goal = Goal.FromCsv(lines[i]);
                _goals.Add(goal);
            }
        }
    }
}
