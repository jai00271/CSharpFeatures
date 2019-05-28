


![alt text](http://strive2code.net/image.axd?picture=/Azure/CSharp/CSharp_versions_min.jpg)

?																		[Credit: Image Source](http://strive2code.net/image.axd?picture=/Azure/CSharp/CSharp_versions_min.jpg)

<ol>

<li>**Async and await**</li>

  Async

The keyword is useful for an asynchronous function. If the user specifies the async keyword before the function user needs to call the function asynchronously.   

```c#
private static async void Feature1_AsyncAwait()
        {
            await DBProcess();
        }
```

  Await

The await keyword is useful when user calls the function asynchronously.   

```c#
private static Task DBProcess()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(7000);
            });
        }**Lambda expressions**
```

<li>**Caller Information**</li>

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
Caller Name: Main
Caller FilePath: C:\Users\User_Name\CSharp5\Program.cs
Caller LineNumber: 13
```

</ol>