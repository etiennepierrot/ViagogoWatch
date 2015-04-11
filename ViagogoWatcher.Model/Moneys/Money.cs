using System.Collections.Generic;

namespace ViagogoWatcher.Model.Moneys
{
    public class Money
    {
        public Money(long amount)
        {
            Amount = amount;
            Currency = "EUR";
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Amount, Currency);
        }

        public long Amount { get; private set; }
        public string Currency { get; private set; }

        public static bool operator >(Money first, Money second)
        {
            return first.Amount > second.Amount;
        }

        public static bool operator >=(Money first, Money second)
        {
            return first.Amount >= second.Amount;
        }

        public static bool operator <=(Money first, Money second)
        {
            return first.Amount <= second.Amount;
        }

        public static bool operator <(Money first, Money second)
        {
            return first.Amount < second.Amount;
        }


        private sealed class CurrencyAmoutEqualityComparer : IEqualityComparer<Money>
        {
            public bool Equals(Money x, Money y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Currency, y.Currency) && x.Amount == y.Amount;
            }

            public int GetHashCode(Money obj)
            {
                unchecked
                {
                    return ((obj.Currency != null ? obj.Currency.GetHashCode() : 0)*397) ^ obj.Amount.GetHashCode();
                }
            }
        }

        private static readonly IEqualityComparer<Money> CurrencyAmoutComparerInstance = new CurrencyAmoutEqualityComparer();

        public static IEqualityComparer<Money> CurrencyAmoutComparer
        {
            get { return CurrencyAmoutComparerInstance; }
        }
    }
}