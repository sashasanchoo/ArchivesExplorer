using ArchivesExplorer.Extensions;
using ArchivesExplorer.Requests;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Aggregates;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivesExplorer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var authResult = await _userService.Register(_mapper.Map<UserModel>(request));
            return Ok(authResult);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            var authResult = await _userService.Login(request.Email!, request.Password!);

            return Ok(authResult);
        }

        [Authorize(Policy = AuthorizationPolicyConstants.AccessTokenPolicy)]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var userId = HttpContext.GetUserId();

            var changePasswordAggregate = _mapper.Map<ChangePasswordAggregateModel>(request);
            changePasswordAggregate.Id = userId;

            await _userService.ChangePassword(changePasswordAggregate);

            return Ok();

        }

        [Authorize(Policy = AuthorizationPolicyConstants.RefreshTokenPolicy)]
        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var userId = HttpContext.GetUserId();

            var newTokens = await _userService.RefreshTokens(userId);

            return Ok(newTokens);
        }

    }
}
