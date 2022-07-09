using Catalogue.Domain.Exceptions;
using System;

namespace Catalogue.Domain.ValueObjects
{
    public class Name
    {
        public string Value { get; set; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidNameException(value);
            if (value.Length > 128 || value.Length < 3)
                throw new InvalidNameException(value);

            Value = value;
        }

        public static implicit operator Name(string value) => value is null ? null : new Name(value);

        public static implicit operator string(Name value) => value.Value;
        public override string ToString() => Value;
    }
}
