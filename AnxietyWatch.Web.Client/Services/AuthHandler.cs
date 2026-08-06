namespace AnxietyWatch.Web.Client.Services;

/// <summary>
/// Inyecta automáticamente <c>Authorization: Bearer &lt;token&gt;</c> en cada
/// petición HTTP si existe una sesión activa.
/// </summary>
public class AuthHandler : DelegatingHandler
{
    private readonly ITokenStore _tokenStore;

    public AuthHandler(ITokenStore tokenStore) => _tokenStore = tokenStore;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken) {
        var token = _tokenStore.GetAccessToken();
        request.Headers.Authorization = string.IsNullOrWhiteSpace(token)
            ? null
            : new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        return base.SendAsync(request, cancellationToken);
    }
}