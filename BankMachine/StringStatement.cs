using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class StringStatement : Statement
    {
        private readonly List<string> _lines;
        private readonly Printer _printer;

        public StringStatement(Printer printer)
        {
            _printer = printer;
            _lines = new List<string>();
        }

        public void AddStatementLine(string line)
        {
            _lines.Add(line);
        }

        public void AddTransactions(List<Transaction> transactions)
        {
            var balance = new Money(0);

            foreach (var transaction in transactions)
            {
                balance = transaction.AddTo(this, balance);
            }
        }

        public void Print()
        {
            string statement = _lines.Aggregate(string.Empty, (current, line) => current + line + @"\n");

            _printer.Print(string.Format(@"date\t\t\tamount\tbalance\t\n{0}", statement));
        }
    }

    [TestFixture]
    public class StatementPrintFormatterTests
    {
        [Test]
        public void Should_print_statement_with_one_transaction()
        {
            var printer = Substitute.For<Printer>();

            var transactions = new StringStatement(printer);

            transactions.AddTransactions(new List<Transaction>
            {
                new Deposit(new DateTime(2015, 12, 15), new Money(20))
            });

            transactions.Print();

            printer.Received().Print(@"date\t\t\tamount\tbalance\t\n15/12/2015\tDEPOSIT\t£20\t£20\n");
        }

        [Test]
        public void Should_print_statement_with_multiple_transactions()
        {
            var printer = Substitute.For<Printer>();

            var transactions = new StringStatement(printer);

            transactions.AddTransactions(new List<Transaction>
            {
                new Deposit(new DateTime(2015, 12, 15), new Money(20)),
                new Deposit(new DateTime(2015, 12, 16), new Money(30))
            });

            transactions.Print();

            printer.Received().Print(@"date\t\t\tamount\tbalance\t\n15/12/2015\tDEPOSIT\t£20\t£20\n16/12/2015\tDEPOSIT\t£30\t£50\n");
        }
    }
}