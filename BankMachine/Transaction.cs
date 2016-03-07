namespace BankMachine
{
    public interface Transaction
    {
        Money Print(Printer printFormatter, Money balance);
    }
}