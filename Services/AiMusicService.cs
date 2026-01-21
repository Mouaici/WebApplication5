using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebApplication4.Services;

public class AiMusicService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public AiMusicService(IConfiguration config)
    {
        _httpClient = new HttpClient();
        _config = config;
    }

    public async Task<string> GeneratePlaylist(string genre, string mood)
    {
        var prompt = $"""
        Generate a radio playlist.
        Genre: {genre}
        Mood: {mood}
        Return 10 tracks as JSON with artist and title.
        """;

        var body = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://api.openai.com/v1/chat/completions"
        );

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", _config["OpenAI:ApiKey"]);

        request.Content = new StringContent(
            JsonSerializer.Serialize(body),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
