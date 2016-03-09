using System.Collections.Generic;

namespace BankMachine
{
    public class CurrentAccount : Account
    {
        private ICollection<Transaction> _transactions;

        public CurrentAccount()
        {
            _transactions = new List<Transaction>();
        }

        public void AddTransactionsTo(Statement statement)
        {
            statement.AddTransactions(_transactions);
        }

        public void Add(Transaction deposit)
        {
            _transactions.Add(deposit);
        }
    }
}