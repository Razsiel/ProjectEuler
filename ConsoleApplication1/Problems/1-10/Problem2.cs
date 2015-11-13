using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Razsiel.Utilities;

namespace ProjectEulerMain
{
    public class Problem2 : IProblem
    {
        const int MAXTERM = 4000000;
        public void FixProblem()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Fibonacci sequence where max term is <4.000.000:");
            Console.ForegroundColor = ConsoleColor.White;
            
            IEnumerable<Int64> fibonacci = GetFibonacciRangeUntilTerm(MAXTERM).Skip(1);

            //int sum = 0;
            /*Old Method using LINQ                                  
            Console.WriteLine(string.Join(" ", fibonacci.TakeWhile(x => { 
                                                                    int temp = sum; 
                                                                    sum += (int)x; 
                                                                    return temp < 4000000; 
                                                                })));*/
            ConsoleUtil.WriteAllLines( string.Join(" ", fibonacci).Wrap(Console.BufferWidth) );
            Console.WriteLine();
            Console.WriteLine("The sum of even fibonacci numbers: {0}", fibonacci.Sum());
        }

        /// <summary>
        /// Returns an IEnumerable range of fibonacci numbers for amount of steps. (0 is included, use .Skip(1) for 1 1 2 3...)
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        public IEnumerable<Int64> GetFibonacciRange(uint steps)
        {
            long previous = -1; 
            long next = 1; 
            long sum = 0;
            for (int i = 0; i < steps; i++)
            {
                sum = previous + next;
                previous = next;
                yield return next = sum;
            }
        }

        /// <summary>
        /// Returns an IEnumarable range of fibonacci numbers until the (exclusive) max term has been reached.
        /// </summary>
        /// <param name="maxTerm"></param>
        /// <returns></returns>
        public IEnumerable<Int64> GetFibonacciRangeUntilTerm(int maxTerm)
        {
            long previous = -1;
            long next = 1;
            long sum = 0;
            while(true)
            {
                sum = previous + next;
                previous = next;
                if (sum > maxTerm)
                    break;
                yield return next = sum;
            }
        }
    }
}
