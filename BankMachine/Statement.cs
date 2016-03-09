using System.Collections.Generic;

namespace BankMachine
{
    public interface Statement
    {
        void AddStatementLine(string format);
        void Print(Account account);
        void AddTransactions(ICollection<Transaction> transactions);
    }
}