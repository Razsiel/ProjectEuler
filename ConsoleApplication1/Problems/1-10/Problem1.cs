using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerMain
{
    public class Problem1 : IProblem
    {
        const int MAXRANGE = 1000;
        public void FixProblem()
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i < MAXRANGE; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    numbers.Add(i);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Natural numbers that are a multiple of 3 or 5:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( string.Join(", ", numbers.Select(n => n)));
            Console.WriteLine();
            
            int sum = numbers.Sum();
            Console.WriteLine("Sum of all numbers in collection: {0}", sum);
        }
    }
}
