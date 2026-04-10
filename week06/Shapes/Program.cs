using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // --- Create Square ---
        Console.Write("Enter color for square: ");
        string squareColor = Console.ReadLine();

        Console.Write("Enter side length: ");
        double side = double.Parse(Console.ReadLine());

        shapes.Add(new Square(squareColor, side));

        // --- Create Rectangle ---
        Console.Write("\nEnter color for rectangle: ");
        string rectColor = Console.ReadLine();

        Console.Write("Enter length: ");
        double length = double.Parse(Console.ReadLine());

        Console.Write("Enter width: ");
        double width = double.Parse(Console.ReadLine());

        shapes.Add(new Rectangle(rectColor, length, width));

        // --- Create Circle ---
        Console.Write("\nEnter color for circle: ");
        string circleColor = Console.ReadLine();

        Console.Write("Enter radius: ");
        double radius = double.Parse(Console.ReadLine());

        shapes.Add(new Circle(circleColor, radius));

        // --- Display Results ---
        Console.WriteLine("\n--- Shape Summary ---");

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():F2}");
            Console.WriteLine();
        }
    }
}