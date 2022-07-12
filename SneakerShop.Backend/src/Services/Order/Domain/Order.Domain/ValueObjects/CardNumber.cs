using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class CardNumber
    {
        public string Value { get; set; }

        public CardNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidCardNumberException(value);

            Value = value;
        }

        public static implicit operator CardNumber(string value) => value is null ? null : new CardNumber(value);

        public static implicit operator string(CardNumber value) => value.Value;

        public override string ToString() => Value;
    }
}
