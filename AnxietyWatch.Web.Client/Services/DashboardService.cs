using System.Text.Json;
using AnxietyWatch.Web.Client.Models.Api;

namespace AnxietyWatch.Web.Client.Services;

public interface IDashboardService
{
    Task<DashboardSummaryDto> GetSummaryAsync(CancellationToken cancellationToken = default);
}

public sealed class DashboardService(HttpClient http, JsonSerializerOptions jsonOptions) : IDashboardService
{
    public async Task<DashboardSummaryDto> GetSummaryAsync(CancellationToken cancellationToken = default)
    {
        using var response = await http.GetAsync("api/dashboard/summary", cancellationToken);
        return await response.ReadApiAsync<DashboardSummaryDto>(jsonOptions, cancellationToken);
    }
}
