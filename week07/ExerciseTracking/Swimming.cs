namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(string date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        // Distance = laps * 50 / 1000
        public override double GetDistance() => (_laps * 50) / 1000.0;

        // Speed = (distance / minutes) * 60
        public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

        // Pace = minutes / distance
        public override double GetPace() => GetMinutes() / GetDistance();
    }
}