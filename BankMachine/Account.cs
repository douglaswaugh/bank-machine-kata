using System.Collections.Generic;

namespace BankMachine
{
    public interface Account
    {
        void Add(Transaction deposit);
        void PrintStatement(Statement account);
        ICollection<Transaction> Transactions { get; }
    }
}