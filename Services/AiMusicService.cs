using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebApplication5.Services;

public class AiMusicService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AiMusicService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        // ✅ THIS LINE FIXES YOUR ERROR
        _httpClient.BaseAddress = new Uri(
            _configuration["AiService:BaseUrl"]!
        );

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                _configuration["AiService:ApiKey"]
            );
    }

    public async Task<List<string>> GeneratePlaylist(string genre, string mood)
    {
        var prompt =
            $"Generate a playlist of 5 {genre} songs with a {mood} mood.";

        var request = new
        {
            model = _configuration["AiService:Model"],
            messages = new[]
            {
                new { role = "system", content = "You are a music curator." },
                new { role = "user", content = prompt }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            "application/json"
        );

        // ✅ EMPTY STRING IS OK because BaseAddress is set
        var response = await _httpClient.PostAsync("", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);

        var text = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return text!
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}
