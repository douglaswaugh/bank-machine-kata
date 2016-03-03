using System;

namespace BankMachine
{
    public class Deposit : Transaction
    {
        private readonly DateTime _date;
        private readonly Money _money;

        public Deposit(DateTime date, Money money)
        {
            _date = date;
            _money = money;
        }

        public void Print(Printer printer, ref Money balance)
        {
            balance = _money.Plus(balance);

            printer.Print(string.Format("{0} DEPOSIT £{1} £{2}", _date.ToShortDateString(), _money, balance));
        }

        #region Equality
        protected bool Equals(Deposit other)
        {
            return _date.Equals(other._date) && Equals(_money, other._money);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Deposit) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_date.GetHashCode()*397) ^ (_money != null ? _money.GetHashCode() : 0);
            }
        }
        #endregion
    }
}