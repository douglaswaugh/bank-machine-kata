namespace BankMachine
{
    public interface Account
    {
        void Add(Transaction deposit);
        void PrintStatement(Statement account);
    }
}