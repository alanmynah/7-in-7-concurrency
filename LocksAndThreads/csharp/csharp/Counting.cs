using System;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using System.Threading;

namespace csharp
{
    /// <summary>
    /// example 2
    /// </summary>
    public static class Counting
    {
        public static void RunExample()
        {
            var counter = new Counter();
            var t1 = new Thread( () => ThreadWork(counter));
            var t2 = new Thread( () => ThreadWork(counter));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(counter.Count);
        }

        private class Counter
        {
            public int Count { get; private set; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            public void Increment() => Count++;
        }

        private static void ThreadWork(Counter counter)
        {
            for (var i = 0; i < 10000; i++)
            {
                counter.Increment();
            }
        }
    }
}