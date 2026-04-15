namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(string date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetSpeed() => _speed;

        // Distance = (speed * minutes) / 60
        public override double GetDistance() => (_speed * GetMinutes()) / 60.0;

        // Pace = 60 / speed
        public override double GetPace() => 60.0 / _speed;
    }
}