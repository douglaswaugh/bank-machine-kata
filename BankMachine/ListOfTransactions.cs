using System.Collections.Generic;

namespace BankMachine
{
    public class ListOfTransactions : Transactions
    {
        private readonly List<Transaction> _transactions;

        public ListOfTransactions()
        {
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction deposit)
        {
            _transactions.Add(deposit);
        }

        public void Print(PrintFormatter printFormatter)
        {
            foreach (var transaction in _transactions)
            {
                transaction.Print(printFormatter);
            }
        }
    }
}