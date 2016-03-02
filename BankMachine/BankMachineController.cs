using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class BankMachineController
    {
        private readonly Transactions _transactions;
        private readonly PrintFormatter _printFormatter;

        public BankMachineController(Transactions transactions, PrintFormatter printFormatter)
        {
            _transactions = transactions;
            _printFormatter = printFormatter;
        }

        public void Deposit(Deposit deposit)
        {
            _transactions.Add(deposit);
        }

        public void PrintStatement()
        {
            _printFormatter.Format(_transactions);
        }
    }

    [TestFixture]
    public class BankMachineControllerTests
    {
        private BankMachineController _bankMachineController;
        private Transactions _transactions;
        private PrintFormatter _printFormatter;

        [SetUp]
        public void SetUp()
        {
            _transactions = Substitute.For<Transactions>();

            _printFormatter = Substitute.For<PrintFormatter>();

            _bankMachineController = new BankMachineController(_transactions, _printFormatter);   
        }

        [Test]
        public void Should_accept_deposit_requests()
        {
            _bankMachineController.Deposit(new Deposit(new DateTime(2016, 3, 2), 20));

            _transactions.Received().Add(new Deposit(new DateTime(2016, 3, 2), 20));
        }

        [Test]
        public void Should_accept_print_statement_requests()
        {
            _bankMachineController.PrintStatement();

            _printFormatter.Received().Format(_transactions);
        }
    }
}
