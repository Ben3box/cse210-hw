namespace ExerciseTracking
{
    public abstract class Activity
    {
        // Encapsulation: private member variables
        private string _date;
        private int _minutes;

        public Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Shared method to allow derived classes to access the minutes for math
        public int GetMinutes() => _minutes;

        // Abstract methods: No implementation here; children MUST override these
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // One summary method for all classes using Polymorphism
        public string GetSummary()
        {
            return $"{_date} {this.GetType().Name} ({_minutes} min): " +
                   $"Distance {GetDistance():0.1} km, Speed {GetSpeed():0.1} kph, " +
                   $"Pace: {GetPace():0.1} min per km";
        }
    }
}