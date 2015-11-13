using System;
using System.Collections;
using System.Collections.Generic;
using Razsiel.Utilities;

namespace ProjectEulerMain
{
    public class Problem3 : IProblem
    {
        const long MAXNUMBER = 600851475143;
        public void FixProblem()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Primes: ");
            Console.ForegroundColor = ConsoleColor.White;
            IEnumerable<Int64> primes = GetPrimes(2000);

            ConsoleUtil.WriteAllLines(string.Join(" ", primes).Wrap(Console.BufferWidth));
            Console.WriteLine();
            ConsoleUtil.ColoredWriteLine(new NotImplementedException().ToString(), ConsoleColor.Red);
        }

        public IEnumerable<Int64> GetPrimes(long max)
        {
            long prime = 0;
            for (int i = 3; i < max; i++)
            {
                if (i.IsPrime())
                {
                    yield return prime = i;
                }
            }
        }
    }

    public static class IntExt
    {
        public static bool IsPrime(this int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
