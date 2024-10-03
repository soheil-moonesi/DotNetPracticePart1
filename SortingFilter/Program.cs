class Program
{
    public static void Main(string[] args)
    {
        List<Person> Persons = new List<Person>()
        {
            new Person() { Id = 1, Name = "soheil", Age = 33 },
            new Person() { Id = 2, Name = "sepehr", Age = 28 },
            new Person() { Id = 3, Name = "sara", Age = 25 },
            new Person() { Id = 4, Name = "samin", Age = 19 },
            new Person() { Id = 5, Name = "sina", Age = 50 },
            new Person() { Id = 6, Name = "Ali", Age = 26 },
            new Person() { Id = 7, Name = "sima", Age = 50 }

        };

        Console.WriteLine("____________OrderByAge______________");
        var dataOrderBy = Persons.OrderBy(p => p.Age);

        foreach (var p in dataOrderBy)
        {
            Console.WriteLine(p.Age);
        }

        var dataOrderByDescending = Persons.OrderByDescending(p => p.Age);
        Console.WriteLine("____________OrderByDescendingAge______________");
        foreach (var p in dataOrderByDescending)
        {
            Console.WriteLine(p.Age);
        }

        Console.WriteLine("____________OrderByName______________");
        var sortingByName = Persons.OrderBy(p => p.Name);
        foreach (var p in sortingByName)
        {
            Console.WriteLine(p.Name);
        }

        Console.WriteLine("____________OrderByNameReverse______________");

        foreach (var p in sortingByName.Reverse())
        {
            Console.WriteLine(p.Name);
        }


        Console.WriteLine("-------MultipleSortNameAge-------");

        var MultipleSortNameAge = Persons.OrderBy(p => p.Age).ThenBy(p => p.Name);
        foreach (var p in MultipleSortNameAge)
        {
            Console.WriteLine($"{p.Name} {p.Age}");
        }



    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}