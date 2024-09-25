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

        var dataOrderBy = Persons.OrderBy(p => p.Age);

        foreach (var p in dataOrderBy)
        {
            Console.WriteLine(p.Age);
        }




    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}