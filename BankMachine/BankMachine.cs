using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class BankMachine
    {
        private readonly Account _account;
        private readonly Statement _statement;

        public BankMachine(Account account, Statement statement)
        {
            _account = account;
            _statement = statement;
        }

        public void Deposit(Deposit deposit)
        {
            _account.Add(deposit);
        }

        public void PrintStatement()
        {
            _statement.Print(_account);
        }
    }

    [TestFixture]
    public class BankMachineTests
    {
        private BankMachine _bankMachine;
        private Account _account;
        private Statement _statement;

        [SetUp]
        public void SetUp()
        {
            _account = Substitute.For<Account>();
            _statement = Substitute.For<Statement>();

            _bankMachine = new BankMachine(_account, _statement);
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

            _statement.Received().Print(Arg.Any<Account>());
        }
    }
}
