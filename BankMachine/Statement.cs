namespace BankMachine
{
    public interface Statement
    {
        void AddStatementLine(string format);
        void Print(Account account);
    }
}