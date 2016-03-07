using System.Collections.Generic;

namespace BankMachine
{
    public class TransactionList : Transactions
    {
        private readonly List<Transaction> _transactions;
        private readonly Statement _statement;

        public TransactionList(Statement statement)
        {
            _statement = statement;
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction deposit)
        {
            _transactions.Add(deposit);
        }

        public void PrintStatement()
        {
            _statement.AddTransactions(_transactions);

            _statement.Print();
        }
    }
}