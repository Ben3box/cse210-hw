using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax and focus by guiding you through deep, rhythmic breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration(); // total duration in seconds
        int elapsed = 0;
        int inhaleTime = 4;
        int exhaleTime = 4;

        while (elapsed < duration)
        {
            // Calculate remaining time
            int remaining = duration - elapsed;

            // Breathe in
            int inhale = Math.Min(inhaleTime, remaining);
            Console.WriteLine("Breathe in...");
            ShowCountDown(inhale);
            elapsed += inhale;

            if (elapsed >= duration) break;

            // Breathe out
            int exhale = Math.Min(exhaleTime, duration - elapsed);
            Console.WriteLine("Breathe out...");
            ShowCountDown(exhale);
            elapsed += exhale;

            // Optional small pause / spinner between cycles
            if (elapsed < duration)
            {
                ShowSpinner(1); // 1-second small pause for flow
            }
        }

        DisplayEndingMessage();
    }
}