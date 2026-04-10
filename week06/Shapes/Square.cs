public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }

    public override string GetSuggestedColor()
    {
        return "Yellow (bright and balanced)";
    }
}