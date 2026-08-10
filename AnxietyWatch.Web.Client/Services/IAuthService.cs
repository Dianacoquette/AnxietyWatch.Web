using AnxietyWatch.Web.Client.Models.Auth;

namespace AnxietyWatch.Web.Client.Services;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
    Task<AuthResponse?> GetSessionAsync();
    Task<AuthMessageResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
    Task<AuthMessageResponse> ResetPasswordAsync(ResetPasswordRequest request);
    Task<EmailVerificationStatusResponse> GetEmailVerificationStatusAsync(CancellationToken cancellationToken = default);
    Task<AuthMessageResponse> ResendEmailVerificationAsync(CancellationToken cancellationToken = default);
}
