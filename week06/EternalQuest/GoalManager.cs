using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private List<Badge> _badges = new List<Badge>();
    private int _score = 0;
    private int _level = 1;

    private readonly Dictionary<int, string> _titles = new Dictionary<int, string>()
    {
        {1,"Novice Adventurer"},
        {2,"Apprentice Tracker"},
        {3,"Scripture Squire"},
        {4,"Temple Pilgrim"},
        {5,"Scripture Knight"},
        {6,"Goal Guardian"},
        {7,"Quest Champion"},
        {8,"Master of Habits"},
        {9,"Legendary Achiever"},
        {10,"Master of Eternal Quest"}
    };

    public GoalManager()
    {
        _badges.Add(new Badge("Beginner", 500));
        _badges.Add(new Badge("Intermediate", 2000));
        _badges.Add(new Badge("Advanced", 5000));
        _badges.Add(new Badge("Master", 10000));
    }

    public void DisplayScore()
    {
        string title = _titles.ContainsKey(_level) ? _titles[_level] : "";
        Console.WriteLine($"\nScore: {_score} | Level: {_level} - {title}");
        DisplayXPBar();
    }

    private void DisplayXPBar()
    {
        int xpForLevel = _level * 1000;
        int prevLevelScore = (_level - 1) * 1000;
        int currentXP = _score - prevLevelScore;
        int barLength = 20;
        int filled = (int)((currentXP / (float)(xpForLevel - prevLevelScore)) * barLength);
        Console.Write("Progress to next level: ");
        Console.WriteLine($"[{new string('█', filled)}{new string('░', barLength - filled)}] {currentXP}/{xpForLevel}");
    }

    public void CreateGoal()
    {
        try
        {
            Console.WriteLine("1. Simple\n2. Eternal\n3. Checklist\n4. Progress\n5. Negative");
            string type = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            int points = ReadInt("Points: ");

            switch (type)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;
                case "3":
                    int target = ReadInt("Target count: ");
                    int bonus = ReadInt("Bonus points: ");
                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                    break;
                case "4":
                    int total = ReadInt("Total steps to complete: ");
                    _goals.Add(new ProgressGoal(name, desc, points, total));
                    break;
                case "5":
                    _goals.Add(new NegativeGoal(name, desc, points));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating goal: {ex.Message}");
        }
    }

    private int ReadInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result)) break;
            Console.WriteLine("Invalid number. Please enter an integer.");
        }
        return result;
    }

    public void ListGoals()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals created."); return; }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetName()}");
        }
    }

    public void RecordEvent()
    {
        try
        {
            ListGoals();
            if (_goals.Count == 0) return;

            int index = ReadInt("Select goal number: ") - 1;
            if (index < 0 || index >= _goals.Count) { Console.WriteLine("Invalid goal number."); return; }

            int earned = _goals[index].RecordEvent();
            _score += earned;

            UpdateLevel();
            CheckBadges();

            Console.WriteLine($"You {(earned >= 0 ? "earned" : "lost")} {Math.Abs(earned)} points!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error recording event: {ex.Message}");
        }
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;
        if (_level > 10) _level = 10;
    }

    private void CheckBadges()
    {
        foreach (Badge b in _badges) b.CheckEarned(_score);
    }

    public void ShowBadges()
    {
        foreach (Badge b in _badges) Console.WriteLine(b.GetStatus());
    }

    public void Save()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                foreach (Goal g in _goals) writer.WriteLine(g.GetStringRepresentation());
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void Load()
    {
        try
        {
            if (!File.Exists("goals.txt")) { Console.WriteLine("Save file not found."); return; }
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))); break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]))); break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[4]))); break;
                    case "ProgressGoal":
                        _goals.Add(new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]))); break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]))); break;
                }
            }
            UpdateLevel();
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}