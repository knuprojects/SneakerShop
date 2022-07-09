using Security.Domain.Common;
using Security.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Security.Domain.Entities
{
    public class User : IBaseEntity
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int UserId { get; set; }
        public Login Login { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool? Deleted { get; set; }

        public virtual IReadOnlyCollection<RefreshToken> RefreshTokens { get; set; }
    }
}
