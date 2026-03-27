using System;

public class Fraction
{
    // That's the Attributes (private fields)
    private int _top;
    private int _bottom;

    // implement the Default constructor
    public Fraction()
    {
        _top = 0;
        _bottom = 1;
    }

    // writing the constructor with whole number
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // writing a constructor with top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // using Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero!");
        }
    }

    // using method to return fraction as string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // using method to return decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}