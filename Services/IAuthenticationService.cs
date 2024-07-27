using System.IdentityModel.Tokens.Jwt;
using personal_finance_api.Dtos;

namespace personal_finance_api.Services;

public interface IAuthenticationService
{ 
    Task<string> Register(RegisterRequest request);
    Task<string> Login(LoginRequest request);
}