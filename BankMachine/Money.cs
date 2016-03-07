namespace BankMachine
{
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
}