using System;

namespace ExerciseTracking
{
    public class CyclingActivity : Activity
    {
        private double _speedMph;

        public CyclingActivity(DateTime date, int lengthInMinutes, double speedMph)
            : base(date, lengthInMinutes)
        {
            _speedMph = Math.Max(0.0, speedMph);
        }

        public override double GetDistanceMiles()
        {
            return _speedMph * (LengthInMinutes / 60.0);
        }

        public override double GetSpeedMph() => _speedMph;

        public override double GetPaceMinPerMile()
        {
            double distance = GetDistanceMiles();
            if (distance <= 0) return 0;
            return (double)LengthInMinutes / distance;
        }
    }
}