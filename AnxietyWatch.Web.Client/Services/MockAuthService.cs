using AnxietyWatch.Web.Client.Models.Auth;

namespace AnxietyWatch.Web.Client.Services;

public class MockAuthService : IAuthService
{
    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        await Task.Delay(1000);

        if (request.Email == "test@correo.com")
        {
            return new AuthResponse
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.mock-token",
                ExpiresAt = DateTimeOffset.UtcNow.AddHours(1),
                User = new UserDto
                {
                    Id = "mock-user-001",
                    FullName = "Usuario de Prueba",
                    Email = request.Email,
                    PlanId = "free"
                }
            };
        }

        throw new UnauthorizedAccessException("Credenciales inválidas.");
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        await Task.Delay(1000);

        return new AuthResponse
        {
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.mock-token-register",
            ExpiresAt = DateTimeOffset.UtcNow.AddHours(1),
            User = new UserDto
            {
                Id = "mock-user-002",
                FullName = request.FullName,
                Email = request.Email,
                PlanId = request.PlanId
            }
        };
    }

    public Task LogoutAsync() => Task.CompletedTask;

    public Task<AuthResponse?> GetSessionAsync() => Task.FromResult<AuthResponse?>(null);
}