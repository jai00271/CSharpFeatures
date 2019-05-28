using System;
using static System.Console;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Feature1_OutVariable();
            WriteLine("-------------------------------------------------------------------");

            Feature2_LocalFunctions();
            WriteLine("-------------------------------------------------------------------");
            ReadLine();
        }

        #region Feature1_OutVariable

        public static void Feature1_OutVariable()
        {
            string s = "28-May-2019";

            if (DateTime.TryParse(s, out DateTime date))
            {
                WriteLine(date);
            }
            WriteLine(date);
        }

        #endregion Feature1_OutVariable

        #region Feature2_LocalFunctions

        public static void Feature2_LocalFunctions()
        {
            void PrintHi()
            {
                WriteLine("Hi");
            }
            void PrintHello()
            {
                WriteLine("Hello");
            }
            PrintHi();
            PrintHello();
        }

        #endregion Feature2_LocalFunctions

    }
}
