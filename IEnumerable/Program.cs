using System;
using System.Diagnostics;
using System.Collections;

//for using LINQ we must Implement IEnumerable<T> because : LINQ queries require a strongly-typed generic collection
public class TestCollection : IEnumerable<string>
{
    public string[] Course = { "Math", "Science", "Philosophy" };

    // Required method for implementing IEnumerable
    // it is use for find and return next element in collection

    public IEnumerator<string> GetEnumerator()
    {
        foreach (var c in Course)
        {
            yield return c;
        }
    }

    // Explicit implementation of non-generic IEnumerable
    //It returns the same enumerator as the generic version,
    //which allows compatibility with non-generic enumeration patterns.
   //IEnumerable itself is non-generic
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); // Call the generic version
    }

}

class Program
{
    static void Main(string[] args)
    {

        TestCollection test = new TestCollection();

        //use foreach to console result
        foreach (var c in test)
        {
            Console.WriteLine(c);
        }

        //use LINQ for Query 
        //start with "from" in Line 1
        //describe Condition in line 2
        //return result with "select" in line 3
        var ResultQuerySyntax = from c in test 
                     where c.Contains("h")
                     select c;

        foreach (var c in ResultQuerySyntax)
        {
            Console.WriteLine(c);
        }

        var ResultMethodSyntax = test.Where(c => c.Contains("P"));

        foreach (var c in ResultMethodSyntax)
        {
            Console.WriteLine(c);
        }

    }
    
}
