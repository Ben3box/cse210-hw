using System;

class Program

{
    static void Main(string[] args)
    {   
        Console.Write("What is your percentage?"); 
        string Response = Console.ReadLine();
        int percentage = int.Parse(Response);

        string Letter = "";
        
       string Sign = "";
        
        if(percentage >= 90)
        {
             Letter = "A";
        }
       
        else if (percentage >= 80)
        {
            Letter = "B";;
        }
        else if (percentage >= 70)
        {
            Letter = "C";
        }
        else if (percentage >= 60)
        {
            Letter = "D";
        }
        else
        {
            Letter = "F";
        }
        int lastdigit = percentage ;

        if(lastdigit >= 7)
        {
           Sign ="+"; 
        }
        else if(percentage < 3)
        {
            Sign = "-";
        }
        else
        {
            Sign = "";
        }
        
        if(Letter == "A" && Sign == "+")
        {
            Sign = "";
        }
        
        if(Letter == "F")
        {
            Sign = "";
        }

        Console.WriteLine($"Your note is : {Letter}{Sign}");

        if(percentage >= 70)
        {
            Console.WriteLine("congratulations, you have passed the course successfully!");
        }
        else
        {
            Console.WriteLine("Don't get discouraged, keep up your efforts for next time!");
        }
    }

    
}
