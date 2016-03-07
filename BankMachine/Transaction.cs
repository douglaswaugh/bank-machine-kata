namespace BankMachine
{
    public interface Transaction
    {
        Money AddTo(Statement statement, Money balance);
    }
}