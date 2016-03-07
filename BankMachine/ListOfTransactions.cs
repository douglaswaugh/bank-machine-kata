using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class ListOfTransactions : Transactions
    {
        private readonly List<Transaction> _transactions;
        private readonly Printer _printer;

        public ListOfTransactions(Printer printer)
        {
            _printer = printer;
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction deposit)
        {
            _transactions.Add(deposit);
        }

        public void Print()
        {
            _transactions.Aggregate(new Money(0), (current, transaction) => transaction.Print(_printer, current));
        }
    }

    [TestFixture]
    public class StatementPrintFormatterTests
    {
        [Test]
        public void Should_print_transactions()
        {
            var printer = Substitute.For<Printer>();

            Transactions transactions = new ListOfTransactions(printer);
            transactions.Add(new Deposit(new DateTime(2015, 12, 15), new Money(20)));

            transactions.Print();

            printer.Received().Print("15/12/2015 DEPOSIT £20 £20");
        }

        [Test]
        public void Should_print_multiple_transactions()
        {
            var printer = Substitute.For<Printer>();

            var transactions = new ListOfTransactions(printer);
            transactions.Add(new Deposit(new DateTime(2015, 12, 15), new Money(20)));
            transactions.Add(new Deposit(new DateTime(2015, 12, 16), new Money(30)));

            transactions.Print();

            printer.Received().Print("15/12/2015 DEPOSIT £20 £20");
            printer.Received().Print("16/12/2015 DEPOSIT £30 £50");
        }
    }
}