
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        //IList can have multiple member with different types
        IList list = new ArrayList();
        list.Add(4);
        list.Add("s");
        list.Add(new Person() { Id = 1, Name = "soheil" });
        list.Add(20);

        var IntResult = list.OfType<int>();

        foreach (var c in IntResult)
        {
            Console.WriteLine(c.ToString());
        }



    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}