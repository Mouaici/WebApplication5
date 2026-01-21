using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/ai/music")]
public class AiMusicController : ControllerBase
{
    private readonly AiMusicService _aiService;

    public AiMusicController(AiMusicService aiService)
    {
        _aiService = aiService;
    }

    [HttpGet("playlist")]
    public async Task<IActionResult> Generate(
        string genre = "Pop",
        string mood = "Energetic")
    {
        var result = await _aiService.GeneratePlaylist(genre, mood);
        return Ok(result);
    }
}
