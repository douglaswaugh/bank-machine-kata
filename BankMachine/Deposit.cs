using System;

namespace BankMachine
{
    public class Deposit : Transaction
    {
        private readonly DateTime _date;
        private readonly int _amount;

        public Deposit(DateTime date, int amount)
        {
            _date = date;
            _amount = amount;
        }

        protected bool Equals(Deposit other)
        {
            return _amount == other._amount && _date.Equals(other._date);
        }

        public void Print(PrintFormatter printFormatter)
        {
            printFormatter.Print(string.Format("{0} DEPOSIT £{1} £{2}", _date.ToShortDateString(), _amount, _amount));
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
                return (_amount*397) ^ _date.GetHashCode();
            }
        }
    }
}