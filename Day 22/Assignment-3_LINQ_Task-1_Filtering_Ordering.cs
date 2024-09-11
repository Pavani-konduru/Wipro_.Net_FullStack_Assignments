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

        // Query to get names of persons whose age is over 30
        var over30Persons = persons.Where(p => p.Age > 30)
                                   .Select(p => $"{p.FirstName} {p.LastName}");

        // Print the names
        Console.WriteLine("***Task-1***");
        Console.WriteLine("Persons over 30 years old:");
        foreach (var name in over30Persons)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine("**************");
        var orderedPersons = persons.OrderBy(p => p.LastName)
                                    .ThenBy(p => p.FirstName);

        // Print the sorted list
        Console.WriteLine("Sorted persons by LastName and FirstName:");
        foreach (var person in orderedPersons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}, Age: {person.Age}");
        }
        Console.WriteLine();
    }
}