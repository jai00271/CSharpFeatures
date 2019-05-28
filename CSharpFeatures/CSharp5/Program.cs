using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharp5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Feature1_AsyncAwait();

            Feature2_CallerInformation();

            Console.ReadLine();
        }

        #region Feature1_AsyncAwait

        private static async void Feature1_AsyncAwait()
        {
            await DBProcess();
        }

        /// <summary>
        /// This process will take time to execute
        /// </summary>
        /// <returns></returns>
        private static Task DBProcess()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(7000);
            });
        }

        #endregion Feature1_AsyncAwait

        #region Feature2_CallerInformation

        public static void Feature2_CallerInformation([CallerMemberName] string name = null, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null)
        {
            Console.WriteLine("Caller Name: {0}", name);
            Console.WriteLine("Caller FilePath: {0}", path);
            Console.WriteLine("Caller LineNumber: {0}", line);
        }

        #endregion Feature2_CallerInformation
    }
}