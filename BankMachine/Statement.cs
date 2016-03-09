namespace BankMachine
{
    public interface Statement
    {
        void AddStatementLine(string format);
        void Prepare(Account account);
        void Print();
    }
}