using Security.Domain.Common;
using Security.Domain.ValueObjects;

namespace Security.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int RefreshTokenId { get; set; }
        public Token Token { get; set; }
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
