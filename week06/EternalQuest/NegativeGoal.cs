using System;

public class NegativeGoal : Goal
{
    private bool _triggered;

    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, penaltyPoints)
    {
        _triggered = false;
    }

    public override int RecordEvent()
    {
        if (!_triggered)
        {
            _triggered = true;
            return -GetPoints();
        }
        return 0;
    }

    public override bool IsComplete() => _triggered;

    public override string GetStatus() => _triggered ? "⚠️" : "⬜";

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_triggered}";
    }
}