using System;
using System.Collections.Generic;
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
            var balance = new Money(0);

            foreach (var transaction in _transactions)
            {
                balance = transaction.Print(_printer, balance);
            }
        }
    }

    public class Money
    {
        private readonly int _amount;

        public Money(int amount)
        {
            _amount = amount;
        }

        public Money Plus(Money other)
        {
            return new Money(_amount + other._amount);
        }

        public override string ToString()
        {
            return _amount.ToString();
        }

        #region Equality
        protected bool Equals(Money other)
        {
            return _amount == other._amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return _amount;
        }
        #endregion
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