using Security.Application.Abstraction;

namespace Security.Application.Commands.RefreshCommand
{
    public class Refresh : ICommand
    {
        public string Token { get; set; }
    }
}
