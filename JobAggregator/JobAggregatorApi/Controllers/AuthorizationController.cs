using JobAggregator.Api.DTO;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthorizationController(IUserService userService,
                                        ITokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var user = await userService.GetByLoginAsync(loginDTO.Login);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var isValidUser = await userService.ValidateUserAsync(loginDTO.Login, loginDTO.Password);
        if (!isValidUser)
        {
            return Unauthorized("Invalid login or password.");
        }
        var (token, expiration) = await tokenService.GenerateAccessToken(user);
        return Ok(new
                {
                    token,
                    expiration
                });
    }
}
