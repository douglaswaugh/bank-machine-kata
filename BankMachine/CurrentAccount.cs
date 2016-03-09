using System.Collections.Generic;

namespace BankMachine
{
    public class CurrentAccount : Account
    {
        private readonly List<Transaction> _transactions;

        public CurrentAccount()
        {
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction deposit)
        {
            _transactions.Add(deposit);
        }

        public void PrintStatement(Statement statement)
        {
            statement.AddTransactions(_transactions);

            statement.Print();
        }
    }
}