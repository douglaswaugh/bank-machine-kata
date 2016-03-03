using System;
using NSubstitute;
using NUnit.Framework;

namespace BankMachine
{
    public class StatementPrintFormatter : PrintFormatter
    {
        private readonly Printer _printer;

        public StatementPrintFormatter(Printer printer)
        {
            _printer = printer;
        }

        public void Format(Transactions transactions)
        {
            transactions.Print(this);
        }

        public void Print(string formattedTransaction)
        {
            _printer.Print(formattedTransaction);
        }
    }

    [TestFixture]
    public class StatementPrintFormatterTests
    {
        [Test]
        public void Should_print_transactions()
        {
            var printer = Substitute.For<Printer>();

            var printFormatter = new StatementPrintFormatter(printer);

            Transactions transactions = new ListOfTransactions();
            transactions.Add(new Deposit(new DateTime(2015, 12, 15), 20));

            printFormatter.Format(transactions);

            printer.Received().Print("15/12/2015 DEPOSIT £20 £20");
        }
    }
}