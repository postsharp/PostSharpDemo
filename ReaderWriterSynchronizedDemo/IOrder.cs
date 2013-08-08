namespace ReaderWriterSynchronizedDemo
{
    interface IOrder
    {
        void Set( int amount, int discount );
        int Amount { get; }
        int Discount { get; }
        int AmountAfterDiscount { get; }
    }
}
