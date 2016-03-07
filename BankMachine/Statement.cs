using System.Collections.Generic;

namespace BankMachine
{
    public interface Statement
    {
        void AddStatementLine(string format);
        void AddTransactions(List<Transaction> transactions);
        void Print();
    }
}