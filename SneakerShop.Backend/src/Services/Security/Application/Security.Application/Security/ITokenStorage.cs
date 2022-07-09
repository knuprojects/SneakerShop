using Security.Application.Dto;

namespace Security.Application.Security
{
    public interface ITokenStorage
    {
        void Set(JwtDto jwt);
        JwtDto Get();
    }
}
