﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Abstraction;
using Security.Application.Commands.AuthenticateCommand;
using Security.Application.Commands.RefreshCommand;
using Security.Application.Commands.RegisterCommand;
using Security.Application.Dto;
using Security.Application.Security;
using Security.Domain.Const;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Api.Controllers
{
    public class SecurityController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly ICommandHandler<Refresh> _refreshHandler;
        private readonly ITokenStorage _tokenStorage;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public SecurityController(
            ICommandHandler<SignUp> signUpHandler,
            ICommandHandler<SignIn> signInHandler,
            ICommandHandler<Refresh> refreshHandler,
            ITokenStorage tokenStorage,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _refreshHandler = refreshHandler;
            _tokenStorage = tokenStorage;
            _refreshTokenRepository = refreshTokenRepository;
        }

        [AllowAnonymous]
        [Route(Routes.Login)]
        [HttpPost]
        public async Task<ActionResult<JwtDto>> Login([FromBody] SignIn command)
        {
            await _signInHandler.HandleAsync(command);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [AllowAnonymous]
        [Route(Routes.Register)]
        [HttpPost]
        public async Task<ActionResult<JwtDto>> Register([FromBody] SignUp command)
        {
            await _signUpHandler.HandleAsync(command);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [Route(Routes.Refresh)]
        [HttpPost]
        public async Task<ActionResult<JwtDto>> RefreshToken([FromBody] Refresh command)
        {
            await _refreshHandler.HandleAsync(command);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [Authorize]
        [Route(Routes.Logout)]
        [HttpDelete]
        public async Task<IActionResult> Logout()
        {
            string rawUserId = HttpContext.User.FindFirstValue("UserId");

            if (!int.TryParse(rawUserId, out int userId))
            {
                return Unauthorized();
            }

            await _refreshTokenRepository.DeleteAllAsync(userId);

            return NoContent();
        }
    }
}
