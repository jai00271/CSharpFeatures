<h3>C* 6.0 features</h3>

<ol>
<li>Using Static</li>

Now to use any static method we don't have to use class name. We can declare namespace with static keyword for that class.

```c#
using static System.Console;

public static void Feature1_UsingStatic()
        {
            //Check namespace declaration: using static System.Console;
            WriteLine("We are using Console.WriteLine() to print this line!");
        }
```

<li>Auto Property Initializer</li>

Instead of creating properties with default get; and set; we can organize them better by assigning default values. We can also make a property readonly by removing set; while property declaration. 

```c#
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
```

In above example Salary is readonly and it can't be modified except Employee constructor. 

```c#
public static void Feature2_AutoPropertyInitializer()
        {
            Employee employee = new Employee();
            WriteLine(employee.Name);
            WriteLine(employee.Age);
            WriteLine(employee.Salary);
        }
```

Now in case if you try to set values for salary you will get below error:

![Error](https://thepracticaldev.s3.amazonaws.com/i/5ozkh82ka2ynwamt9898.png)

<li>Dictionary Initializer</li>

When using dictionaries, sometimes you want to initialize them with values just as you can do with arrays and lists using "=". We can now do it using something called dictionary initializers which work very similar to array initializers.

```c#
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
Output:
-------------------------------------------------------------------
Dictionary key is: 1 and value is: Amar
Dictionary key is: 2 and value is: Akbar
Dictionary key is: 3 and value is: Anthony
Dictionary key is: 4 and value is: Siddhu
```

<li>nameOf Expression</li>

This feature is very useful for developers. If you notice above, in all WriteLine methods we have been mentioning Id in string and trying to print the values. Why not use the property name itself and make our life easy.

```c#
public static void Feature4_NameOfExpression()
        {
            Employee employee = new Employee();
            WriteLine("{0} : {1}", nameof(employee.Name), employee.Name);
            WriteLine("{0} : {1}", nameof(employee.Age), employee.Age);
            WriteLine("{0} : {1}", nameof(employee.Salary), employee.Salary);
        }
Output:
-------------------------------------------------------------------
Name : Jai
Age : 30
Salary : 111
```

<li>Exception filters</li>

Exception filters allow us to specify a condition within a catch block so if the condition will return true then the catch block is executed else it won't.

```c#
public static void Feature5_ExceptionFilters()
        {
            int denominator = 3;

            try
            {
                WriteLine(3 / denominator);
            }
            catch (DivideByZeroException exception)
            {
                if (denominator == 2)
                {
                    WriteLine("If catch executed");
                }
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message);
            }
        }
```

<li>Await In Catch And Finally Block</li>

Now you can have async calls from catch and finally block. This is very useful as sometime we may want to perform some operation like writing logs, caching, DB calls without blocking the execution.

```c#
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
Output:
-------------------------------------------------------------------
Inside Catch Async call
Inside Finally Async call
```

<li>Null Conditional Operator</li>

Instead of checking null condition in traditional way, we can make use of in-line null-conditional operator. This operator helps in removing lot of null's and if conditions.

```c#
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
public static void Feature7_NullConditionalOperator()
    {
        Customer customer = new Customer();
        WriteLine(customer?.Name);
        WriteLine(customer?.Order?.ProductName);
        WriteLine(customer?.Order?.Description ?? "No description provided");
    }
Output:
-------------------------------------------------------------------
Jai
TShirt
No description provided
```

<li>Expression–Bodied Methods</li>

Incase your method just contains one line, you can use expression body method using lambda expression.

```c#
public static void Feature8_ExpressionBodiedMethods()
        {
            WriteLine(PrintMessage());
        }
private static string PrintMessage() => "Have a great day!";
```

<li>Format Strings Using Interpolation</li>

Now you don't need to format string using string.Format(). Trust me this feature has saved lot of my time and I don't have to worry about maintaining format while writing logs statement in code.

```c#
public static void Feature9_FormatStringsUsingInterpolation()
        {
            Employee employee = new Employee();
            WriteLine($"Name is: {employee.Name}, age is: {employee.Age}");
        }
```

</ol>

------






