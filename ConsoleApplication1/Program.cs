using System;
using System.Reflection;
using System.IO;
using System.Xml;
using Razsiel.Utilities;

namespace ProjectEulerMain
{
    public class Program
    {
        const string BASEPATH = "..\\..\\";
        const string XMLSUMMARYFILE = BASEPATH + "Xml\\ProblemSummary.xml";

        public static void Main(string[] args)
        {
            Console.WindowHeight = 52;

            uint identifier = 0;
            do
            {
                Console.Clear();
                //Pretty intro text
                ConsoleExt.WriteToEndOfLine('#');
                Console.WriteLine();
                Console.WriteLine("\t Welcome to my Project Euler solver program! \n");
                ConsoleExt.WriteToEndOfLine('#');
                Console.WriteLine();
                Console.Write("Please input a number (1-522) to pick a problem: ");
            } 
            while ( !uint.TryParse(Console.ReadLine(), out identifier));

            Console.WriteLine();
            string problemName = "Problem" + identifier;

            //Uses Reflection to see whether the class exists in this assembly
            Type t = Type.GetType("ProjectEulerMain." + problemName);
            if (t == null)
            {
                ConsoleUtil.ColoredWriteLine("Sorry... this problem can not be found or hasn't been implemented yet...", ConsoleColor.Red);
                ConsoleExt.WaitForKeyRestart(args);
            }
            //Create a new instance of the type found through Reflection and cast it to IProblem.
            //TODO: Could cause problems if found type does not inherit from IProblem...
            IProblem problem = (IProblem)Activator.CreateInstance(t);

            //Load XML summary document and search for a node with the chosen problem
            XmlDocument summary = new XmlDocument();
            summary.Load(XMLSUMMARYFILE);
            XmlNode node = summary.DocumentElement.SelectSingleNode(problemName);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("({0})", problemName));

            if (node != null)
                ConsoleUtil.WriteAllLines(node.InnerText.Trim().Wrap(Console.BufferWidth - 2));
            else
                Console.WriteLine("Summary not found!\n");

            Console.WriteLine();
            Console.WriteLine("<Solution>");
            Console.ForegroundColor = ConsoleColor.White;
            
            //Actually fix problem!
            problem.FixProblem();

            ConsoleExt.WaitForKeyRestart(args);
        }
    }

    public static class ConsoleExt
    {
        public static void WriteToEndOfLine(char c)
        {
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(c);
            }
        }

        public static void WriteAt(char c, int charPosition)
        {
            Console.SetCursorPosition(charPosition, Console.CursorTop);
            Console.Write(c);
        }

        public static void WaitForKeyRestart(string[] args) 
        {
            Console.WriteLine();
            Console.Write("Press any button to start over...");
            Console.ReadKey();
            Program.Main(args);
        }
    }
}
