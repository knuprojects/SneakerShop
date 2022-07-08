using Security.Domain.Common;

namespace Security.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int RefreshTokenId { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
