using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Person p1= new Person();
        p1.fistname = "Benjamin";
        p1.lastname = "Iriganje";
        p1.age = 30;   

        Person p2 = new Person();
        p2.fistname = "Salatielle";
        p2.lastname = "Manayankakagayo";
        p2.age = 24;

        Person p3 = new Person();
        p3.fistname = "Olave";
        p3.lastname = "Iradukunda";
        p3.age = 16;

        List<Person>people = new List<Person>();
        people.Add(p1);
        people.Add(p2);
        people.Add(p3);   

       foreach (Person p in people)
        {
            Console.WriteLine(p.fistname);
        }

       
        SaveToFile(people);
    }
       public static void SaveToFile(List<Person> people)
        {
            Console.WriteLine("SaveToFile...");

            string filename = "people.txt";

            using (StreamWriter outputfile = new StreamWriter(filename))
            {
                foreach(Person p in people)
            {
                outputfile.WriteLine($"{p.fistname}~~~~ {p.lastname}~~~~~ {p.age}");
            }
            }

        
        }
       public static List<Person> ReadFromfile()
{ 
    List<Person> people = new List<Person>(); 
    string filename = "people.txt"; 
    string[] lines = System.IO.File.ReadAllLines(filename);
    
    foreach(string line in lines)
        {
           // Console.WriteLine(line);
           // line will have something like this
           string[]parts = line.Split("~~~~");
           //parts[o]=Benjamin
           //parts[1]=Iriganje
           //parts[2]=age
           Person newPerson = new Person();
           newPerson.fistname = parts[0];
           newPerson.lastname = parts[1];
           newPerson.age = int.Parse(parts[2]);
        }
    return people; 
} 
}
