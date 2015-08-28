using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PostSharp.Patterns.Threading;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 100000;
            const int threadCount = 16;
            Counter counter = new Counter();
            Thread[] threads = new Thread[threadCount];

            // Start threads.
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
               {
                   // Do the work.
                   for (int j = 0; j < n; j++)
                   {
                       counter.Increment();
                   }
               });
                threads[i].Start();
            }

            // Wait for threads.
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            int expectedValue = n * threadCount;
            Console.WriteLine("Counter.Value={0}. Expected value is {1}. Difference is {2}%", counter.Value, expectedValue, 100.0 * (expectedValue - counter.Value) / (double) expectedValue );

        }
    }

    [ReaderWriterSynchronized]
    class Counter
    {
        int value;

        public int Value {  get { return this.value; } }

        [Writer]
        public void Increment()
        {
            this.value++;
        }
    }
}
