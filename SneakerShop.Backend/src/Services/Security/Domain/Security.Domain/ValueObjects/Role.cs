using Security.Domain.Const;
using Security.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Security.Domain.ValueObjects
{
    public class Role
    {
        public static IReadOnlyCollection<string> AvailableRoles { get; } = new[] { Useful.AdminRole, Useful.UserRole };

        public string Value { get; }

        public Role(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
                throw new InvalidRoleException(value);

            if (!AvailableRoles.Contains(value))
                throw new InvalidRoleException(value);

            Value = value;
        }

        public static Role Admin() => new Role(Useful.AdminRole);

        public static Role User() => new Role(Useful.UserRole);

        public static implicit operator Role(string value) => new Role(value);

        public static implicit operator string(Role value) => value?.Value;

        public override string ToString() => Value;
    }
}
