namespace Security.Application.Exceptions
{
    public class InvalidRefreshToken : CustomException
    {
        public string Token { get; }

        public InvalidRefreshToken(string token) : base($"Refresh token: {token} is invalid!")
        {
            Token = token;
        }
    }
}
