using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Infrastructure.Security;

public sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated =>
        User?.Identity?.IsAuthenticated == true;

    public int? UserId
    {
        get
        {
            var value = GetClaimValue(ClaimTypes.NameIdentifier)
                ?? GetClaimValue(ClaimTypes.Name)
                ?? GetClaimValue("sub");

            return int.TryParse(value, out var userId)
                ? userId
                : null;
        }
    }

    public string? Email =>
        GetClaimValue(ClaimTypes.Email)
        ?? GetClaimValue("email");

    public string? Role =>
        GetClaimValue(ClaimTypes.Role);

    private string? GetClaimValue(string claimType)
    {
        return User?.FindFirst(claimType)?.Value;
    }
}
