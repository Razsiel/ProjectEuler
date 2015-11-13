using System;
using Razsiel.Utilities;

namespace ProjectEulerMain
{
    public class Problem4 : IProblem
    {
        const int MAXTHREEDIGITS = 999;
        const int MINTHREEDIGITS = 100;

        public void FixProblem()
        {
            int palindrome = 0;
            int a = 0;
            int b = 0;
            for (a = MAXTHREEDIGITS; a > MINTHREEDIGITS; a--)
            {
                for (b = MAXTHREEDIGITS; b > MINTHREEDIGITS; b--)
                {
                    int result = a * b;
                    if (result.ToString().IsPalindrome())
                    {
                        palindrome = result;
                        break;
                    }
                }
                if (palindrome != 0)
                    break;
            }

            Console.WriteLine("Highest possible palindrome with 3 digits: {0}", palindrome);
            Console.WriteLine("Result gotten through calculation: {0} x {1}", a, b);
        }
    }
}