using System;

class Program
{
    static void Main(string[] args)
    {
        // Math Assignment
        MathAssignment math = new MathAssignment(
            "John Smith",
            "Fractions",
            "7.3",
            "3-10, 20-21"
        );

        Console.WriteLine("Math Assignment:");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        // Writing Assignment
        WritingAssignment writing = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        Console.WriteLine("Writing Assignment:");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}