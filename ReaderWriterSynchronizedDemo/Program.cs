using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderWriterSynchronizedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           // new TestReaderWriterLock<ThreadUnsafeOrder>().Test();
            
            new TestReaderWriterLock<ManuallySynchronizedOrder>().Test();
            new TestReaderWriterLock<SynchronizedOrder>().Test();
        }
    }
}
