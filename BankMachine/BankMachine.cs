using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class BankMachine
    {
        private readonly Transactions _transactions;

        public BankMachine(Transactions transactions)
        {
            _transactions = transactions;
        }

        public void Deposit(Deposit deposit)
        {
            _transactions.Add(deposit);
        }

        public void PrintStatement()
        {
            _transactions.PrintStatement();
        }
    }

    [TestFixture]
    public class BankMachineTests
    {
        private BankMachine _bankMachine;
        private Transactions _transactions;

        [SetUp]
        public void SetUp()
        {
            _transactions = Substitute.For<Transactions>();

            _bankMachine = new BankMachine(_transactions);
        }

        [Test]
        public void Should_accept_deposit_requests()
        {
            _bankMachine.Deposit(new Deposit(new DateTime(2016, 3, 2), new Money(20)));

            _transactions.Received().Add(new Deposit(new DateTime(2016, 3, 2), new Money(20)));
        }

        [Test]
        public void Should_accept_print_statement_requests()
        {
            _bankMachine.PrintStatement();

            _transactions.Received().PrintStatement();
        }
    }
}
