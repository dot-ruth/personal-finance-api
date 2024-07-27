using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using personal_finance_api.Dtos;
using personal_finance_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace personal_finance_api.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService (UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> Register(RegisterRequest request)
    {
        var userByUsername = await _userManager.FindByNameAsync(request.userName);
        if ( userByUsername is not null)
        {
            throw new ArgumentException($"username {request.userName} already exists.");
        }

        User user = new()
        {
            UserName = request.userName,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.password);

        if(!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {request.userName} errors: {GetErrorsText(result.Errors)}");
        }

        return await Login(new LoginRequest { userName = request.userName, password = request.password });
    }

    public async Task<string> Login(LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.userName);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.password))
        {
            throw new ArgumentException($"Unable to authenticate user {request.userName}");
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = GetToken(authClaims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}