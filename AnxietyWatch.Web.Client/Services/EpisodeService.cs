using System.Net.Http.Json;
using System.Text.Json;
using AnxietyWatch.Web.Client.Models.Api;

namespace AnxietyWatch.Web.Client.Services;

public interface IEpisodeService
{
    Task<IReadOnlyList<EpisodeDto>> GetEpisodesAsync(int range = 7, CancellationToken cancellationToken = default);
    Task<EpisodeDto> CreateEpisodeAsync(CreateEpisodeRequest request, CancellationToken cancellationToken = default);
}

public sealed class EpisodeService(HttpClient http, JsonSerializerOptions jsonOptions) : IEpisodeService
{
    public async Task<IReadOnlyList<EpisodeDto>> GetEpisodesAsync(
        int range = 7,
        CancellationToken cancellationToken = default)
    {
        if (range is not (7 or 30 or 90))
        {
            throw new ArgumentOutOfRangeException(nameof(range), range, "Range must be 7, 30, or 90 days.");
        }

        using var response = await http.GetAsync($"api/episodes?range={range}", cancellationToken);
        return await response.ReadApiAsync<IReadOnlyList<EpisodeDto>>(jsonOptions, cancellationToken);
    }

    public async Task<EpisodeDto> CreateEpisodeAsync(
        CreateEpisodeRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response = await http.PostAsJsonAsync("api/episodes", request, jsonOptions, cancellationToken);
        return await response.ReadApiAsync<EpisodeDto>(jsonOptions, cancellationToken);
    }
}
