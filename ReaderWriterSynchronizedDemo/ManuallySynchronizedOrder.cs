using System;
using System.Threading;

namespace ReaderWriterSynchronizedDemo
{
    class ManuallySynchronizedOrder : IOrder
    {
        readonly ReaderWriterLockSlim  @lock = new ReaderWriterLockSlim();

        public void Set(int amount, int discount)
        {
            if (amount < discount) throw new InvalidOperationException();

            this.@lock.EnterWriteLock();
            this.Amount = amount;
            this.Discount = discount;
            this.@lock.ExitWriteLock();
        }

        public int Amount { get; private set; }
        public int Discount { get; private set; }

        public int AmountAfterDiscount
        {
            get
            {
                this.@lock.EnterReadLock();
                int result = this.Amount - this.Discount;
                this.@lock.ExitReadLock();
                return result;

            }
        }
    }
}