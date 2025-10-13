using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class SwimmingActivity : Activity
    {
        private int _laps;
        private const double metersPerLap = 50.0;
        private const double metersToMiles = 0.000621371;

        public SwimmingActivity(DateTime date, int lengthInMinutes, int laps)
            : base(date, lengthInMinutes)
        {
            _laps = Math.Max(0, laps);
        }

        public override double GetDistanceMiles()
        {
            double distanceMeters = _laps * metersPerLap;
            return distanceMeters * metersToMiles;
        }

        public override double GetSpeedMph()
        {
            double distanceMiles = GetDistanceMiles();
            if (LengthInMinutes <= 0 || distanceMiles <= 0) return 0;
            return (distanceMiles / LengthInMinutes) * 60.0;
        }

        public override double GetPaceMinPerMile()
        {
            double distanceMiles = GetDistanceMiles();
            if (distanceMiles <= 0) return 0;
            return (double)LengthInMinutes / distanceMiles;
        }
    }
}