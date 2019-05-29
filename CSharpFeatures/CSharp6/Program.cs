using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Feature1_UsingStatic();
            WriteLine("-------------------------------------------------------------------");

            Feature2_AutoPropertyInitializer();
            WriteLine("-------------------------------------------------------------------");

            Feature3_DictionaryInitializer();
            WriteLine("-------------------------------------------------------------------");

            Feature4_NameOfExpression();
            WriteLine("-------------------------------------------------------------------");

            Feature5_ExceptionFilters();
            WriteLine("-------------------------------------------------------------------");

            Feature6_AwaitInCatchAndFinallyBlock();
            WriteLine("-------------------------------------------------------------------");

            Feature7_NullConditionalOperator();
            WriteLine("-------------------------------------------------------------------");

            Feature8_ExpressionBodiedMethods();
            WriteLine("-------------------------------------------------------------------");

            ReadLine();
        }

        #region Feature1_UsingStatic

        public static void Feature1_UsingStatic()
        {
            //Check namespace declaration: using static System.Console;
            WriteLine("We are using Console.WriteLine() to print this line!");
        }

        #endregion Feature1_UsingStatic

        #region Feature2_AutoPropertyInitializer

        public static void Feature2_AutoPropertyInitializer()
        {
            Employee employee = new Employee();
            WriteLine(employee.Name);
            WriteLine(employee.Age);
            WriteLine(employee.Salary);

            //employee = new Employee() { Age = 11, Name = "Jai", Salary = 100 };
        }

        #endregion Feature2_AutoPropertyInitializer

        #region Feature3_DictionaryInitializer

        public static void Feature3_DictionaryInitializer()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {
                [1] = "Amar",
                [2] = "Akbar",
                [3] = "Anthony"
            };
            dictionary[4] = "Siddhu";
            foreach (var item in dictionary)
            {
                WriteLine("Dictionary key is: {0} and value is: {1}", item.Key, item.Value);
            }
        }

        #endregion Feature3_DictionaryInitializer

        #region Feature4_NameOfExpression

        public static void Feature4_NameOfExpression()
        {
            Employee employee = new Employee();
            WriteLine("{0} : {1}", nameof(employee.Name), employee.Name);
            WriteLine("{0} : {1}", nameof(employee.Age), employee.Age);
            WriteLine("{0} : {1}", nameof(employee.Salary), employee.Salary);
        }

        #endregion Feature4_NameOfExpression

        #region Feature5_ExceptionFilters

        public static void Feature5_ExceptionFilters()
        {
            int denominator = 0;

            try
            {
                WriteLine(3 / denominator);
            }
            catch (DivideByZeroException exception) when (denominator == 2)
            {
                WriteLine("If catch executed");
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message);
            }
        }

        #endregion Feature5_ExceptionFilters

        #region Feature6_AwaitInCatchAndFinallyBlock

        public static async void Feature6_AwaitInCatchAndFinallyBlock()
        {
            int denominator = 0;

            try
            {
                WriteLine(3 / denominator);
            }
            catch (DivideByZeroException exception)
            {
                await FromCatch();
            }
            finally
            {
                await FromFinally();
            }
        }

        private static async Task FromCatch()
        {
            WriteLine("Inside Catch Async call");
        }

        private static async Task FromFinally()
        {
            WriteLine("Inside Finally Async call");
        }

        #endregion Feature6_AwaitInCatchAndFinallyBlock

        #region Feature7_NullConditionalOperator

        public static void Feature7_NullConditionalOperator()
        {
            Customer customer = new Customer();
            WriteLine(customer?.Name);
            WriteLine(customer?.Order?.ProductName);
            WriteLine(customer?.Order?.Description ?? "No description provided");
        }

        #endregion Feature7_NullConditionalOperator

        #region Feature8_ExpressionBodiedMethods

        public static void Feature8_ExpressionBodiedMethods()
        {
            WriteLine(PrintMessage());
        }

        private static string PrintMessage() => "Have a great day!";

        #endregion Feature8_ExpressionBodiedMethods

        #region Feature9_FormatStringsUsingInterpolation

        public static void Feature9_FormatStringsUsingInterpolation()
        {
            Employee employee = new Employee();
            WriteLine($"Name is: {employee.Name}, age is: {employee.Age}");
        }

        #endregion Feature9_FormatStringsUsingInterpolation
    }

    public class Employee
    {
        public Employee()
        {
            Salary = 111;
        }

        public string Name { get; set; } = "Jai";
        public int Age { get; set; } = 30;
        public int Salary { get; } = 222;
    }

    public class Customer
    {
        public int ItemNo { get; set; } = 123;
        public string Name { get; set; } = "Jai";
        public Order Order { get; set; } = new Order();
    }

    public class Order
    {
        public int OrderId { get; set; } = 321;
        public string ProductName { get; set; } = "TShirt";
        public string Description { get; set; } = null;
    }
}