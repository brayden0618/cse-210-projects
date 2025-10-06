using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _title;
        protected string _description;
        protected int _points;

        protected Goal(string title, string description, int points)
        {
            _title = title;
            _description = description;
            _points = Math.Max(0, points);
        }

        public string Title => _title;
        public string Description => _description;
        public int Points => _points;

        public abstract bool IsComplete { get; }
        public abstract int RecordEvent();
        public abstract string GetStatusString();
        public abstract string ToCsv();

        public static Goal FromCsv(string line)
        {
            var parts = line.Split('|');
            if (parts.Length < 4) throw new FormatException("Invalid goal format");

            var type = parts[0];
            var title = parts[1];
            var description = parts[2];
            var points = int.Parse(parts[3]);

            switch (type)
            {
                case "Simple":
                    bool done = parts.Length > 4 && bool.Parse(parts[4]);
                    var g = new SimpleGoal(title, description, points);
                    if (done) g.RecordEvent();
                    return g;

                case "Eternal":
                    return new EternalGoal(title, description, points);

                case "Checklist":
                    if (parts.Length < 7) throw new FormatException("Invalid checklist goal format");
                    int target = int.Parse(parts[4]);
                    int current = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var cg = new ChecklistGoal(title, description, points, target, bonus);
                    for (int i = 0; i < current; i++) cg.RecordEvent();
                    return cg;

                default:
                    throw new FormatException("Unknown goal type");
            }
        }
    }
}