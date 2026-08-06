using System.Net.Http.Json;
using System.Text.Json;
using AnxietyWatch.Web.Client.Models.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace AnxietyWatch.Web.Client.Services;

/// <summary>
/// Implementación real de <see cref="IAuthService"/> contra el backend REST.
/// Tras login/register guarda la sesión y avisa al proveedor de estado.
/// </summary>
public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly ITokenStore _tokenStore;
    private readonly ApiAuthenticationStateProvider _authStateProvider;

    public AuthService(
        HttpClient http,
        ITokenStore tokenStore,
        ApiAuthenticationStateProvider authState) {
        _http = http;
        _tokenStore = tokenStore;
        _authStateProvider = authState;
    }

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", request, JsonOptions);
        var session = await response.ReadApiAsync<AuthResponse>(JsonOptions);
        await StoreSessionAsync(session);
        return session;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", request, JsonOptions);
        var session = await response.ReadApiAsync<AuthResponse>(JsonOptions);
        await StoreSessionAsync(session);
        return session;
    }

    public async Task LogoutAsync()
    {
        try
        {
            var _ = await _http.PostAsync("api/auth/logout", null);
        }
        catch
        {
            // La revocación es best-effort; se cierra la sesión local igualmente.
        }

        await _tokenStore.ClearAsync();
        _authStateProvider.NotifyAuthenticationStateChanged();
    }

    public async Task<AuthResponse?> GetSessionAsync()
    {
        var response = await _http.GetAsync("api/auth/session");
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            await LogoutAsync();
            return null;
        }

        var session = await response.ReadApiAsync<AuthResponse>(JsonOptions);
        await StoreSessionAsync(session);
        return session;
    }

    private async Task StoreSessionAsync(AuthResponse session)
    {
        await _tokenStore.StoreAsync(session);
        _authStateProvider.NotifyAuthenticationStateChanged();
    }
}