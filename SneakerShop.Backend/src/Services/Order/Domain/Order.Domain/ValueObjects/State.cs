using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class State
    {
        public string Value { get; set; }

        public State(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidStateException(value);

            Value = value;
        }

        public static implicit operator State(string value) => value is null ? null : new State(value);

        public static implicit operator string(State state) => state.Value;

        public override string ToString() => Value;
    }
}
