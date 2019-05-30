As we know recently c# version 8.0 was launched which is still in preview as I write this article. Its final version will be released together with .NET Core 3.0. Unlike all the versions of the language so far, not all features of C# 8.0 will be available in the .NET framework.  

So I thought of listing some key features of c# from 5.0 to 7.0 which is currently scattered across the web under 1 umbrella. I have added Git link also for reference. 

Before starting I sincerely want to thank Microsoft and various websites/bloggers.

Fyi I am using asp .Net core 2.2 for all projects.

<h3>C* 5.0 features</h3>

![alt text](http://strive2code.net/image.axd?picture=/Azure/CSharp/CSharp_versions_min.jpg)

​																		[Credit: Image Source](http://strive2code.net/image.axd?picture=/Azure/CSharp/CSharp_versions_min.jpg)

<ol>

<li>Async and await</li>

  Async

The keyword is useful for an asynchronous function. If the user specifies the async keyword before the function user needs to call the function asynchronously.   

  Await

The await keyword is useful when user calls the function asynchronously.   

```c#
private static async void Feature1_AsyncAwait()
{
    await DBProcess();
}

private static Task DBProcess()
{
    return Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(7000);
                    });
}
```

<li>Caller Information</li>

You can fetch caller info using Caller attribute. It is useful for debugging, tracing, etc purpose.

Three different attribute types are used in the caller information.

<ol>
<li>CallerFilePath: It is used to set information about the caller source code file</li>
<li>CallerMemberName: It is used to set the information about the caller member name</li>
<li>CallerLineNumber: It is used to set the information about the line number of the caller</li></ol>

```c#
public static void Feature2_CallerInformation([CallerMemberName] string name = null, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null)
{
    Console.WriteLine("Caller Name: {0}", name);
    Console.WriteLine("Caller FilePath: {0}", path);
    Console.WriteLine("Caller LineNumber: {0}", line);
}

Output:
-------------------------------------------------------------------
Caller Name: Main
Caller FilePath: C:\Users\User_Name\CSharp5\Program.cs
Caller LineNumber: 13
```

</ol>

------

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

<h3>C* 7.0 features</h3>

<ol>
    <li>out variables</li>  
    You can declare out values inline as arguments to the method where they're used.

​    ![alt text](https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/top-10-new-features-of-c-sharp-7-with-visual-studio-2017/Images/10.png)

```c#
public static void Feature1_OutVariable()
{
    string s = "28-May-2019";
    if (DateTime.TryParse(s, out DateTime date))
    {
    	WriteLine(date);
    }
    WriteLine(date);
}
```

<li>Local Functions</li>

Now we can have local functions instead of multiple separate private function.

```c#
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
```

<li>Tuples (with types and literals)</li>

Return multiple values from a method is now a common practice, we generally use custom datatype, out parameters, Dynamic return type or a tuple object but here C# 7.0 brings **tuple types** and **tuple literals** for you it just return multiple values/ multiple type inform of tuple object. 

```c#
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
```

Tuples are very useful thing where you can replace hash table or dictionary easily, even you can return multiple values for a single key, Additionally you can use it instead of List where you store multiple values at single position.

.NET also has a Tuple type ([See here](https://msdn.microsoft.com/en-us/library/system.tuple)) but it is a *reference type* and that leads to performance issue, but C# 7.0 bring a Tuple with *value type* which is faster in performance and a mutable type.

<li>Pattern Matching</li>

Is pattern matching is a new feature which can used for checking conditions. Pattern matching supports a lot of patterns like Type Pattern, Constant Pattern, Var Pattern, Recursive Pattern, Property Pattern & Property Sub-pattern, Switch Statement, Match Expression, Case expression, Throw expression, De structuring assignment, Testing Nullable, Arithmetic simplification, Tuple decomposition, Complex Pattern, Wildcard Pattern etc.

```c#
public static void Feature4_PatternMatching_If()
{
    int denominator = 0;

    if (denominator is 0)
    {
        WriteLine("Inside If");
    }
}
```

*Switch pattern* helps a lot as it uses any datatype for matching additionally 'case' clauses also can have its pattern so it bit flexible implementation. In below sample switch case checks pattern and call 'Multiply' method

```c#
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
Output:
-------------------------------------------------------------------
The performer Jai
Not found
Argument Null Exception
```

<li>Ref returns and locals</li>

Earlier we only had option to use ‘ref’ keyword while passing a parameter to a method. Now with C# 7.0, we can also use ‘ref’ for returning a variable from a method i.e. a method can return variable with reference. We can also store a local variable with reference. 

```c#
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
```

<li>Throw Expressions</li>

You can throw exceptions in code constructs that previously weren't allowed because `throw` was a statement. No need of try catch, Hurray!

```c#
public static void Feature6_ThrowExpressions()
        {
            var denominator = 0;
            WriteLine(Divide(denominator));
            
            double Divide(int denom)
            {
                var numerator = 3;
                return denom != 0 ? numerator / denom : throw new DivideByZeroException();
            }
        }
```

<li>Generalized async return types</li>

Methods declared with the `async` modifier can return other types in addition to `Task` and `Task<T>`.

Returning a `Task` object from async methods can introduce performance bottlenecks in certain paths. `Task` is a reference type, so using it means allocating an object. In cases where a method declared with the `async`modifier returns a cached result, or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. It can become costly if those allocations occur in tight loops.

The new language feature means that async method return types aren't limited to `Task`, `Task<T>`, and `void`. The returned type must still satisfy the async pattern, meaning a `GetAwaiter` method must be accessible. As one concrete example, the `ValueTask` type has been added to the .NET framework/ Core to make use of this new language feature:

```c#
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
```

There is a major difference between `Task` and `ValueTask`. The `Task` is a reference type and requires heap allocation. The `ValueTask` is a value type and is returned by value – meaning, no heap allocation. It’s recommended to use `ValueTask` when there is a high probability that a method won’t have to wait for `async` operations. For example, if a method returns cached or predefined results. This can significantly reduce the number of allocations and result in big performance improvement.

<li>Expression-Bodied Members</li>

C# 6 introduced [expression-bodied members](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#expression-bodied-function-members) for member functions, and read-only properties. C# 7.0 expands the allowed members that can be implemented as expressions. In C# 7.0, you can implement *constructors*, *finalizers*, and `get` and `set` accessors on *properties* and *indexers*.

```c#
// Expression-bodied constructor
public ExpressionMembersExample(string label) => this.Label = label;

// Expression-bodied finalizer
~ExpressionMembersExample() => Console.Error.WriteLine("Finalized!");

private string label;

// Expression-bodied get / set accessors.
public string Label
{
    get => label;
    set => this.label = value ?? "Default label";
}
```
