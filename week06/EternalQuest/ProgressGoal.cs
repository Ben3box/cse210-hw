using System;

public class ProgressGoal : Goal
{
    private int _total;
    private int _current;

    public ProgressGoal(string name, string description, int pointsPerStep, int total, int current = 0)
        : base(name, description, pointsPerStep)
    {
        _total = total;
        _current = current;
    }

    public override int RecordEvent()
    {
        if (_current >= _total) return 0;
        _current++;
        return GetPoints();
    }

    public override bool IsComplete() => _current >= _total;

    public override string GetStatus() => $"[{(_current >= _total ? "✅" : "⬜")}] {_current}/{_total}";

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_current}|{_total}";
    }
}