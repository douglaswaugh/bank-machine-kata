using System.Collections.Generic;

namespace BankMachine
{
    public interface Account
    {
        void Add(Transaction deposit);
        ICollection<Transaction> Transactions { get; }
    }
}