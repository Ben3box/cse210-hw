using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Showing List of the base class type
            List<Activity> activities = new List<Activity>();

            // Creating activities
            activities.Add(new Running("15 Apr 2026", 30, 4.8));
            activities.Add(new Cycling("15 Apr 2026", 30, 15.0));
            activities.Add(new Swimming("15 Apr 2026", 30, 20));

            // Iterating and printing the summary of each activity
            Console.WriteLine("Exercise Tracking Summary:");
            Console.WriteLine("--------------------------");
            
            foreach (Activity activity in activities)
            {
                // Each activity calls its specific version of the math
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}