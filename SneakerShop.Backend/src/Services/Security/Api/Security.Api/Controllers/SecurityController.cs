using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Abstraction;
using Security.Application.Commands.AuthenticateCommand;
using Security.Application.Commands.RegisterCommand;
using Security.Application.Dto;
using Security.Application.Security;
using Security.Domain.Const;
using System.Threading.Tasks;

namespace Security.Api.Controllers
{
    public class SecurityController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly ITokenStorage _tokenStorage;

        public SecurityController(
            ICommandHandler<SignUp> signUpHandler,
            ICommandHandler<SignIn> signInHandler,
            ITokenStorage tokenStorage)
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _tokenStorage = tokenStorage;
        }

        [AllowAnonymous]
        [Route(Routes.Login)]
        [HttpPost]
        public async Task<ActionResult<JwtDto>> Login(SignIn command)
        {
            await _signInHandler.HandleAsync(command);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [AllowAnonymous]
        [Route(Routes.Register)]
        [HttpPost]
        public async Task<ActionResult<JwtDto>> Register(SignUp command)
        {
            await _signUpHandler.HandleAsync(command);
            return Ok();
        }
    }
}
