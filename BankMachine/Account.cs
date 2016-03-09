namespace BankMachine
{
    public interface Account
    {
        void Add(Transaction deposit);
        void AddTransactionsTo(Statement statement);
    }
}