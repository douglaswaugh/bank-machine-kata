namespace BankMachine
{
    public interface PrintFormatter
    {
        void Format(Transactions transactions);
        void Print(string formattedTransaction);
    }
}