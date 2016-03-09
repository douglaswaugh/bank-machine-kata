using System.Collections.Generic;

namespace BankMachine
{
    public class CurrentAccount : Account
    {
        public CurrentAccount()
        {
            Transactions = new List<Transaction>();
        }

        public ICollection<Transaction> Transactions { get; private set; } 

        public void Add(Transaction deposit)
        {
            Transactions.Add(deposit);
        }
    }
}