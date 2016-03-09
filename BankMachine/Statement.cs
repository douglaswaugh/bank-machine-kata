namespace BankMachine
{
    public interface Statement
    {
        void AddStatementLine(string format);
        void AddTransactions(Account account);
        void Print();
    }
}