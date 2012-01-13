using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	class Program
	{
        static void Main(string[] args)
        {
            Console.WriteLine("This is a test");
            ICollection<List<string>> s = new List<List<string>>()
            {
                new List<string>() { "a", "b", "c" },
                new List<string>() { "d", "e", "c" },
                new List<string>() { "e", "f", "g" }
            };

            s.SelectMany(x => x.First()).ToList().ForEach(y => Console.WriteLine(y));

            Console.ReadLine();
        }
	}
}
