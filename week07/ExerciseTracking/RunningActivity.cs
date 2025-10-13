using System;

namespace ExerciseTracking
{
    public class RunningActivity : Activity
    {
        private double _distanceMiles;

        public RunningActivity(DateTime date, int lengthInMinutes, double distanceMiles)
            : base(date, lengthInMinutes)
        {
            _distanceMiles = Math.Max(0, distanceMiles);
        }

        public override double GetDistanceMiles() => _distanceMiles;

        public override double GetSpeedMph()
        {
            if (LengthInMinutes <= 0 || _distanceMiles <= 0) return 0;
            return (_distanceMiles / LengthInMinutes) * 60;
        }

        public override double GetPaceMinPerMile()
        {
            if (_distanceMiles <= 0) return 0;
            return (double)LengthInMinutes / _distanceMiles;
        }

    }
}