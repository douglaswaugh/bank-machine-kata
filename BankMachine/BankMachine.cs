using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class BankMachine
    {
        private readonly Account _account;
        private readonly Printer _printer;

        public BankMachine(Account account, Printer printer)
        {
            _account = account;
            _printer = printer;
        }

        public void Deposit(Deposit deposit)
        {
            _account.Add(deposit);
        }

        public void PrintStatement()
        {
            _account.PrintStatement(new StandardStatement(_printer));
        }
    }

    [TestFixture]
    public class BankMachineTests
    {
        private BankMachine _bankMachine;
        private Account _account;
        private Printer _printer;

        [SetUp]
        public void SetUp()
        {
            _account = Substitute.For<Account>();
            _printer = Substitute.For<Printer>();

            _bankMachine = new BankMachine(_account, _printer);
        }

        [Test]
        public void Should_accept_deposit_requests()
        {
            _bankMachine.Deposit(new Deposit(new DateTime(2016, 3, 2), new Money(20)));

            _account.Received().Add(new Deposit(new DateTime(2016, 3, 2), new Money(20)));
        }

        [Test]
        public void Should_accept_print_statement_requests()
        {
            _bankMachine.PrintStatement();

            _account.Received().PrintStatement(Arg.Any<Statement>());
        }
    }
}
