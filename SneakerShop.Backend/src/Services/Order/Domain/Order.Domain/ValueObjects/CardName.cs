using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class CardName
    {
        public string Value { get; set; }

        public CardName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidCarNameException(value);

            Value = value;
        }

        public static implicit operator CardName(string value) => value is null ? null : new CardName(value);

        public static implicit operator string(CardName value) => value.Value;
        public override string ToString() => Value;
    }
}
