using System;
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

