using TaskManagement.Application.Features.Auth.DTOs;

namespace TaskManagement.Application.Features.Auth;

public interface IAuthService
{
    Task<LoginResponse> RegisterAsync(RegisterRequest request);

    Task<LoginResponse> LoginAsync(LoginRequest request);
}
