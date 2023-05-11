//Write queries using LINQ for following operations
//1. Get all people from USA
//2. Get all people above 30
//3. Sort people by name
//4. Project/Select only Name and Country of all people


using System;
using System.Collections.Generic;
using System.Linq;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
}
class Program
{
    static void Main()
    {
        // Create a list of Person objects
        List<Person> people = new List<Person> {
            new Person { Name = "John", Age = 25, Country = "USA" },
            new Person { Name = "Jane", Age = 30, Country = "Canada" },
            new Person { Name = "Mark", Age = 28, Country = "USA" },
            new Person { Name = "Emily", Age = 22, Country = "Australia" },
        };
        // Use LINQ to filter the list and retrieve all the people above a certain age
        int minimumAge = 30;
        var olderPeople = people.Where(p => p.Age >= minimumAge);
        Console.WriteLine($"People above {minimumAge} years old:");
        foreach (var person in olderPeople)
        {
            Console.WriteLine($"{person.Name} ({person.Country}) - {person.Age} years old");
        }
        // Use LINQ to sort the list by name in ascending order
        var sortedPeople = people.OrderBy(p => p.Name);
        Console.WriteLine("\nPeople sorted by name:");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name} ({person.Country}) ");
        }
        // Use LINQ to project the list into a new list of objects with just the Name and Country properties
        var nameCountryList = people.Select(p => new { p.Name, p.Country });
        Console.WriteLine("\nName and country list:");
        foreach (var nc in nameCountryList)
        {
            Console.WriteLine($"{nc.Name} ({nc.Country})");
        }
        List<Person> peopleFromUSA = people.Where(p => p.Country == "USA").ToList();

        Console.WriteLine("People from usa");
        foreach(Person person in peopleFromUSA)

        {
            Console.WriteLine(person.Name);
        }


    }
   
    
}








