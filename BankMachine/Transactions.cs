namespace BankMachine
{
    public interface Transactions
    {
        void Add(Transaction deposit);
        void Print();
    }
}