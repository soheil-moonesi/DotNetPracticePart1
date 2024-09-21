using System;
using System.ComponentModel;
using System.IO.Enumeration;
//for more info https://stasoz.medium.com/deferred-execution-vs-immediate-execution-linq-c42a5f35a571
//based on business logic we must use this two methods 
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
            new Person() { Id = 5, Name = "sina", Age = 50 }
        };
        //Deferred Execution
        //LINQ is Deferred Execution by default 
        //request is not executed here and now,
        //it will be executed when iterating in a loop or when the collection will be iterated in some other way.
        //in line below just create Query structure
        var result = Persons.Where(c => c.Age > 26);

        //it is executed in "result" when we iterate over it
        foreach (var c in result)
        {
            Console.WriteLine(c.Age);
        }

        Persons.Add(new Person() { Id = 6, Name = "fatima", Age = 60 });

        //Immediate execution returns the result immediately, but for this you need to apply one of the methods of immediate execution.
        //These methods can return an atomic value, single element or a list:
        //when we use ToList it is executed 
        var ImmediateExecution = Persons.Where(c => c.Age > 26).ToList();

        foreach (var c in ImmediateExecution)
        {
            Console.WriteLine(c.Age);
        }

    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}