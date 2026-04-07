using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflecting", "This activity helps you reflect on meaningful experiences.")
    {
        _prompts = new List<string>
        {
            "Think of a time you overcame a challenge.",
            "Think of a time you helped someone.",
            "Think of a time you did something difficult."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful?",
            "What did you learn?",
            "How did you feel?",
            "What would you do differently?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
        ShowSpinner(5);
    }
}