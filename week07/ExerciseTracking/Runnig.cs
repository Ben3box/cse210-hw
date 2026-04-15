namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distance;

        public Running(string date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;

        // Speed = (distance / minutes) * 60
        public override double GetSpeed() => (_distance / GetMinutes()) * 60;

        // Pace = minutes / distance
        public override double GetPace() => GetMinutes() / _distance;
    }
}