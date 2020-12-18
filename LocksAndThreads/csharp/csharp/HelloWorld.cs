using System;
using System.Threading;

namespace csharp
{
    /// <summary>
    /// Example 1
    /// </summary>
    public static class HelloWorld
    {
        public static void RunExample()
        {
            var myThread = new Thread(() => Console.WriteLine("Hello from new thread"));
            myThread.Start();
            Thread.Yield(); // this somewhat improves chances of new thread finishing before the main one. 
            // just as Paul Butcher mentions in the book, without yielding, main thread mostly finishes first. 
            Console.WriteLine("Hello from main thread");
        }
    }
}