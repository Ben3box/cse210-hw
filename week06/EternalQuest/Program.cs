using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            try
            {
                manager.DisplayScore();
                Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save\n5. Load\n6. Show Badges\n7. Quit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": manager.CreateGoal(); break;
                    case "2": manager.ListGoals(); break;
                    case "3": manager.RecordEvent(); break;
                    case "4": manager.Save(); break;
                    case "5": manager.Load(); break;
                    case "6": manager.ShowBadges(); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}