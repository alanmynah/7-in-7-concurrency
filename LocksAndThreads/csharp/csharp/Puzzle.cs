using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace csharp
{
    /// <summary>
    /// example 3
    /// </summary>
    public static class Puzzle
    {
        public static void RunExample()
        {
            var answerReady = true;
            var answer = 0;

            var t1 = new Thread(() =>
            {
                answer = 42;
                answerReady = true;
            });
            
            var t2 = new Thread(() =>
            {
                Console.WriteLine(answerReady ? $"The meaning of life is {answer}" : "I don't know the answer");
            });
            
            t2.Start(); // otherwise t1 is almost 100% quicker
            // observe "The meaning of life is 0" printed. mind-blown
            t1.Start();
            t1.Join();
            t2.Join();
        }
    }
}