using System;
using PostSharp.Patterns.Threading;

namespace ReaderWriterSynchronizedDemo
{
    [ReaderWriterSynchronized]
    class SynchronizedOrder : IOrder
    {
        [WriterLock]
        public void Set(int amount, int discount)
        {
            if (amount < discount) throw new InvalidOperationException();
            this.Amount = amount;
            this.Discount = discount;
        }


        public int Amount { [ReaderLock] get; private set; }

        public int Discount { [ReaderLock] get; private set; }

        public int AmountAfterDiscount
        {
            [ReaderLock] get { return this.Amount - this.Discount; }
        }
    }
}