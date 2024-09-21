using System;
using System.IO.Enumeration;

class Program
{
    public static void Main(string[] args)
    {
        List<Person> Persons = new List<Person>();
        Persons.Add(new Person() { Id = 1, Name = "soheil" });
        Persons.Add(new Person() { Id = 2, Name = "sepehr" });
        Persons.Add(new Person() { Id = 3, Name = "sara" });
        Persons.Add(new Person() { Id = 4, Name = "samin" });
        Persons.Add(new Person() { Id = 5, Name = "sina" });

        var ResultByLambda = Persons.Where(c => c.Name.Contains("i"));

        Console.WriteLine("-------ResultByLambda----");

        foreach (var c in ResultByLambda)
        {
            Console.WriteLine(c.Name);
        }

        //use func overload 
        //Func get any type of input and can return any type of output.
        var ResultByFunc = Persons.Where(FindByFunc);
        Console.WriteLine("-------ResultByFunc----");

        foreach (var c in ResultByFunc)
        {

            Console.WriteLine(c.Name);
        }

        //use func and index
        var ResultByFuncIndex = Persons.Where(FindByFuncIndex);
        Console.WriteLine("-------ResultByFuncIndex----");

        foreach (var c in ResultByFuncIndex)
        {

            Console.WriteLine(c.Name);
        }


        var ResultChainWhere = Persons.Where(c => c.Id > 1).Where(c => c.Name.Contains("s"));
        Console.WriteLine("-------ResultChainWhere----");

        foreach (var c in ResultChainWhere)
        {
            Console.WriteLine(c.Name);
        }

        var ResultFuncIndexLambda = Persons.Where((person, index) =>
            {
                if (index % 2 == 0)
                {
                    return true;
                }
                return false;
            }
        );
        Console.WriteLine("-------ResultFuncIndexLambda----");

        foreach (var c in ResultFuncIndexLambda)
        {

            Console.WriteLine(c.Name);
        }

    }

    private static bool FindByFunc(Person person)
    {
        if (person.Id > 1 && person.Id < 4)
        {
            return true;
        }
        return false;
    }

    private static bool FindByFuncIndex(Person person, int index)
    {
        if (index >= 2 && index <= 4)
        {
            return true;
        }

        return false;
    }

    

}


public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}