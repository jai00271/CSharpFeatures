using System;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Feature1_OutVariable();
            WriteLine("-------------------------------------------------------------------");

            Feature2_LocalFunctions();
            WriteLine("-------------------------------------------------------------------");

            Feature3_Tuples();
            WriteLine("-------------------------------------------------------------------");

            Feature4_PatternMatching_If();
            Feature4_PatternMatching_Switch();
            WriteLine("-------------------------------------------------------------------");

            Feature5_RefLocalsAndReturns();
            WriteLine("-------------------------------------------------------------------");

            Feature6_ThrowExpressions();
            WriteLine("-------------------------------------------------------------------");

            Feature7_GeneralizedAsyncReturnTypes();
            WriteLine("-------------------------------------------------------------------");

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

        #region Feature3_Tuples

        public static void Feature3_Tuples()
        {
            (string, string, string) PrintDetails()
            {
                //read EmpInfo from database or any other source and just return them
                string name = "Jai";
                string address = "India";
                string moto = "learning";
                return (name, address, moto); // tuple literal
            }

            var empInfo = PrintDetails();
            WriteLine($"employee info is {empInfo.Item1} {empInfo.Item2} {empInfo.Item3}");
        }

        #endregion Feature3_Tuples

        #region Feature4_PatternMatching_IsAndSwitch

        public static void Feature4_PatternMatching_If()
        {
            int denominator = 0;

            if (denominator is 0)
            {
                WriteLine("Inside If");
            }
        }

        public static void Feature4_PatternMatching_Switch()
        {
            Employee p = new Employee();
            Department d = new Department()
            {
                DeptName = "IT",
                Year = 2006
            };
            Performance a = new Performance()
            {
                Name = "Jai",
                Age = 30,
                Gender = "Male",
                Bonus = "Sometimes",
                Comment = "generic Comment"
            };

            SwitchCase(a);
            SwitchCase(d);
            SwitchCase(p = null);

            void SwitchCase(dynamic instance)
            {
                switch (instance)
                {
                    case Employee performer when (performer.Age == 30):
                        WriteLine($"The performer {performer.Name}");
                        break;

                    default:
                        WriteLine("Not found");
                        break;

                    case null:
                        WriteLine("Argument Null Exception");
                        //throw new ArgumentNullException(nameof(a));
                        break;
                }
            }
        }

        #endregion Feature4_PatternMatching_IsAndSwitch

        #region Feature5_RefLocalsAndReturns

        public static void Feature5_RefLocalsAndReturns()
        {
            int[] arr = { 2, 4, 6, 8, 9 };
            ref int oddNum = ref GetFirstOddNumber(arr);

            WriteLine($"Odd Number: {oddNum}");

            ref int GetFirstOddNumber(int[] numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 1)
                    {
                        return ref numbers[i];
                    }
                }
                throw new Exception("odd number not found");
            }
        }

        #endregion Feature5_RefLocalsAndReturns

        #region Feature6_ThrowExpressions

        public static void Feature6_ThrowExpressions()
        {
            var denominator = 1;
            WriteLine(Divide(denominator));

            double Divide(int denom)
            {
                var numerator = 3;
                return denom != 0 ? numerator / denom : throw new DivideByZeroException();
            }
        }

        #endregion Feature6_ThrowExpressions

        #region Feature7_GeneralizedAsyncReturnTypes

        public static void Feature7_GeneralizedAsyncReturnTypes()
        {
            NoReturn();
            WriteLine("Returned value is: " + WithReturn().Result);

            async ValueTask NoReturn()
            {
                await Task.Delay(1);
            }

            async ValueTask<int> WithReturn()
            {
                await Task.Delay(1);
                return 1;
            }
        }

        #endregion Feature7_GeneralizedAsyncReturnTypes
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class Department : Employee
    {
        public string DeptName { get; set; }
        public int Year { get; set; }
    }

    public class Performance : Employee
    {
        public string Comment { get; set; }
        public string Bonus { get; set; }
    }
}