using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class BankMachineController
    {
        private readonly Transactions _transactions;

        public BankMachineController(Transactions transactions)
        {
            _transactions = transactions;
        }

        public void Deposit(Deposit deposit)
        {
            _transactions.Add(deposit);
        }

        public void PrintStatement()
        {
            _transactions.Print();
        }
    }

    [TestFixture]
    public class BankMachineControllerTests
    {
        private BankMachineController _bankMachineController;
        private Transactions _transactions;

        [SetUp]
        public void SetUp()
        {
            _transactions = Substitute.For<Transactions>();

            _bankMachineController = new BankMachineController(_transactions);   
        }

        [Test]
        public void Should_accept_deposit_requests()
        {
            _bankMachineController.Deposit(new Deposit(new DateTime(2016, 3, 2), new Money(20)));

            _transactions.Received().Add(new Deposit(new DateTime(2016, 3, 2), new Money(20)));
        }

        [Test]
        public void Should_accept_print_statement_requests()
        {
            _bankMachineController.PrintStatement();

            _transactions.Received().Print();
        }
    }
}
