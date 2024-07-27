using personal_finance_api.Dtos;
using personal_finance_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public UserController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _authenticationService.Login(request);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await _authenticationService.Register(request);

        return Ok(response);
    }
}