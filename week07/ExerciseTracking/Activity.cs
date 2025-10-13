using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _lengthInMinutes;

        protected Activity(DateTime date, int lengthInMinutes)
        {
            _date = date.Date;
            _lengthInMinutes = Math.Max(0, lengthInMinutes);
        }

        protected DateTime DateValue => _date;
        protected int LengthInMinutes => _lengthInMinutes;

        public abstract double GetDistanceMiles();
        public abstract double GetSpeedMph();
        public abstract double GetPaceMinPerMile();

        public virtual string GetSummary()
        {
            string date = _date.ToString("MM/dd/yyyy");
            string typeName = this.GetType().Name.Replace("Activity", "");
            double distance = GetDistanceMiles();
            double speed = GetSpeedMph();
            double pace = GetPaceMinPerMile();

            return $"{date} - {typeName} ({_lengthInMinutes} min) - Distance: {distance:F2} miles, Speed: {speed:F2} mph, Pace: {pace:F2} min/mile";
        }
    }
}