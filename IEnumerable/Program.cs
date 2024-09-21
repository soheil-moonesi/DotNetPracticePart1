﻿using System;
using System.Diagnostics;
using System.Collections;


public class TestCollection : IEnumerable
{
    public string[] Course = { "Math", "Science", "Philosophy" };

    // Required method for implementing IEnumerable
    // it is use for find and return next element in collection

    public IEnumerator GetEnumerator()
    {
        foreach (var c in Course)
        {
            yield return c;
        }
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

    }

}
