using Security.Domain.Common;
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
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? Deleted { get; set; }

        public virtual IReadOnlyCollection<RefreshToken> RefreshTokens { get; set; }
    }
}
