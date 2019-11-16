using System;
using System.Collections.Generic;
using System.Threading;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //HackerRankTests.RunTests();

            Thread.Sleep(5000);
            StackOverflowException(1);
        }

        static void StackOverflowException(int x)
        {
            Console.WriteLine(x);

            StackOverflowException(++x);
        }
    }
}
