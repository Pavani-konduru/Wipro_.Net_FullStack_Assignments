using System;
using System.Collections.Generic;
using System.Linq;
class LINQ_Filtering_Ordering
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
    static void Main()
    {
        List<Person> persons = new List<Person>
        {
            new Person { FirstName = "Pavani", LastName = "Doe", Age = 28, Gender = "Male", Salary = 50000 },
            new Person { FirstName = "Rani", LastName = "Smith", Age = 35, Gender = "Female", Salary = 60000 },
            new Person { FirstName = "Bhavana", LastName = "Johnson", Age = 42, Gender = "Female", Salary = 70000 },
            new Person { FirstName = "Tharun", LastName = "Joe", Age = 31, Gender = "Male", Salary = 55000 },
            new Person { FirstName = "Lakshmi", LastName = "Davis", Age = 25, Gender = "Female", Salary = 45000 }
        };
        // a) Calculate the average age of all persons
        double averageAge = persons.Average(p => p.Age);
        Console.WriteLine("***Task-2***");
        Console.WriteLine($"Average Age of All Persons: {averageAge:F2}");
        Console.WriteLine();
        // b) Find and print the oldest and youngest person's full name
        var oldestPerson = persons.OrderByDescending(p => p.Age).FirstOrDefault();
        var youngestPerson = persons.OrderBy(p => p.Age).FirstOrDefault();

        if (oldestPerson != null)
        {
            Console.WriteLine($"Oldest Person: {oldestPerson.FirstName} {oldestPerson.LastName}, Age: {oldestPerson.Age}");
        }

        if (youngestPerson != null)
        {
            Console.WriteLine($"Youngest Person: {youngestPerson.FirstName} {youngestPerson.LastName}, Age: {youngestPerson.Age}");
        }
    }
}