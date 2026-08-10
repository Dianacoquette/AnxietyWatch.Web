using System.Text.Json;
using AnxietyWatch.Web.Client.Models.Api;

namespace AnxietyWatch.Web.Client.Services;

public interface IContentService
{
    Task<IReadOnlyList<FaqDto>> GetFaqAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TestimonialDto>> GetTestimonialsAsync(CancellationToken cancellationToken = default);
}

public sealed class ContentService(HttpClient http, JsonSerializerOptions jsonOptions) : IContentService
{
    public async Task<IReadOnlyList<FaqDto>> GetFaqAsync(CancellationToken cancellationToken = default)
    {
        using var response = await http.GetAsync("api/content/faq", cancellationToken);
        return await response.ReadApiAsync<IReadOnlyList<FaqDto>>(jsonOptions, cancellationToken);
    }

    public async Task<IReadOnlyList<TestimonialDto>> GetTestimonialsAsync(
        CancellationToken cancellationToken = default)
    {
        using var response = await http.GetAsync("api/content/testimonials", cancellationToken);
        return await response.ReadApiAsync<IReadOnlyList<TestimonialDto>>(jsonOptions, cancellationToken);
    }
}
