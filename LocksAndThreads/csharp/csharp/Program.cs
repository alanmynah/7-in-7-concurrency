using System;
using System.Net;
using System.Threading;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld.RunExample();
        }
        
        private static class HelloWorld
        {
            public static void RunExample()
            {
                var myThread = new Thread(ThreadWork);
                myThread.Start();
                Thread.Yield(); // this somewhat improves chances of new thread finishing before the main one. 
                // just as Paul Butcher mentions in the book, without yielding, main thread mostly finishes first. 
                Console.WriteLine("Hello from main thread");
            }
            
            private static void ThreadWork()
            {
                Console.WriteLine("Hello from new thread");
            }
        }
    }
}