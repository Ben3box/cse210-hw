public class Badge
{
    private string _name;
    private int _requiredPoints;
    private bool _earned;

    public Badge(string name, int requiredPoints)
    {
        _name = name;
        _requiredPoints = requiredPoints;
        _earned = false;
    }

    public void CheckEarned(int score)
    {
        if (!_earned && score >= _requiredPoints)
        {
            _earned = true;
            Console.WriteLine($"🏆 Badge Unlocked: {_name}!");
        }
    }

    public string GetStatus() => $"{_name} - {(_earned ? "Unlocked" : "Locked")}";
}