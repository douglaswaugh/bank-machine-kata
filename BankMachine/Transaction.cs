namespace BankMachine
{
    public interface Transaction
    {
        void Print(Printer printFormatter, ref Money balance);
    }
}