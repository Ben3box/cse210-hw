using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity helps you relax by guiding your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int time = 0;
        int duration = GetDuration();

        while (time < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);

            Console.WriteLine("Breathe out...");
            ShowCountDown(4);

            time += 8;
        }

        DisplayEndingMessage();
    }
}